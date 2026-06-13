import { readdirSync } from 'fs';
import { join } from 'path';
import { runTests } from './framework/testRunner';
import { Problem } from './framework/problem';

const args = process.argv.slice(2).filter(a => a !== '--');
const command = args[0]?.toLowerCase();

switch (command) {
	case 'test':
		runTest(parseInt(args[1]));
		break;
	case 'info':
		showInfo(parseInt(args[1]));
		break;
	case 'list':
		listProblems();
		break;
	default:
		showHelp();
}

function loadProblem(n: number): Problem | null {
	const padded = String(n).padStart(3, '0');
	const filePath = join(__dirname, 'problems', `Problem${padded}.ts`);
	try {
		// eslint-disable-next-line @typescript-eslint/no-require-imports
		const mod = require(filePath) as Record<string, unknown>;
		const cls = Object.values(mod).find(
			(v): v is new () => Problem => typeof v === 'function' && v.name.startsWith('Problem')
		);
		return cls ? new cls() : null;
	} catch {
		return null;
	}
}

function runTest(n: number): void {
	if (isNaN(n)) { console.log('Usage: npx tsx run.ts test <number>'); return; }
	const problem = loadProblem(n);
	if (!problem) {
		console.log(`Problem ${n} not found. Create TypeScript/problems/Problem${String(n).padStart(3, '0')}.ts`);
		return;
	}
	runTests(problem);
}

function showInfo(n: number): void {
	if (isNaN(n)) { console.log('Usage: npx tsx run.ts info <number>'); return; }
	const problem = loadProblem(n);
	if (!problem) { console.log(`Problem ${n} not found.`); return; }
	problem.displayProblemInfo();
}

function listProblems(): void {
	const problemsDir = join(__dirname, 'problems');
	let files: string[];
	try {
		files = readdirSync(problemsDir)
			.filter(f => /^Problem\d+\.ts$/.test(f))
			.sort();
	} catch {
		console.log('No problems directory found.');
		return;
	}

	if (files.length === 0) {
		console.log('No TypeScript problems yet.');
		return;
	}

	console.log('TypeScript Problems:');
	console.log('-'.repeat(60));
	console.log(`${'#'.padEnd(4)} ${'Title'.padEnd(30)} ${'Difficulty'.padEnd(10)} Status`);
	console.log('-'.repeat(60));

	let solved = 0;
	for (const file of files) {
		// eslint-disable-next-line @typescript-eslint/no-require-imports
		const mod = require(join(__dirname, 'problems', file)) as Record<string, unknown>;
		const cls = Object.values(mod).find(
			(v): v is new () => Problem => typeof v === 'function' && v.name.startsWith('Problem')
		);
		if (!cls) continue;
		const p = new cls();
		const ok = p.isSolved();
		if (ok) solved++;
		const status = ok ? '✅ SOLVED' : '❌ TODO';
		console.log(`${String(p.number).padStart(3).padEnd(4)} ${p.title.padEnd(30)} ${p.difficulty.padEnd(10)} ${status}`);
	}

	console.log('-'.repeat(60));
	console.log(`Progress: ${solved}/${files.length} problems solved`);
}

function showHelp(): void {
	console.log('BeetCode TypeScript');
	console.log('='.repeat(40));
	console.log('Usage: npx tsx run.ts <command> [args]');
	console.log();
	console.log('Commands:');
	console.log('  test <n>    Run tests for problem number');
	console.log('  list        List all problems and solve status');
	console.log('  info <n>    Show problem description');
	console.log();
	console.log('npm shortcuts:');
	console.log('  npm run list');
	console.log('  npm test -- 1');
	console.log('  npm run info -- 1');
}
