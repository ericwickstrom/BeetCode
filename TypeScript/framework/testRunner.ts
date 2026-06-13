import { Problem } from './problem';
import { ListNode, TreeNode } from './types';

export function runTests(problem: Problem): void {
	console.log(`Running tests for Problem ${problem.number}: ${problem.title}`);
	console.log('-'.repeat(50));

	const testCases = problem.getTestCases();
	let passed = 0;
	const total = testCases.length;
	const perf: { timeMs: number; success: boolean }[] = [];

	for (const tc of testCases) {
		process.stdout.write(`${tc.name}: `);

		try {
			const start = performance.now();
			const result = problem.executeSolution(tc.input);
			const elapsed = performance.now() - start;
			const success = problem.areEqual(result, tc.expected);

			if (success) {
				console.log(`PASS - ${formatTime(elapsed)}`);
				passed++;
			} else {
				console.log(`FAIL - ${formatTime(elapsed)}`);
				console.log(`  Expected: ${formatResult(tc.expected)}`);
				console.log(`  Actual:   ${formatResult(result)}`);
			}

			perf.push({ timeMs: elapsed, success });
		} catch (ex) {
			console.log('ERROR');
			console.log(`  Exception: ${(ex as Error).message}`);
			perf.push({ timeMs: 0, success: false });
		}

		console.log();
	}

	console.log('-'.repeat(50));
	console.log(`Results: ${passed}/${total} tests passed`);

	if (passed === total) {
		console.log('All tests passed! 🎉');
	}

	const successful = perf.filter(r => r.success);
	if (successful.length > 0) {
		const totalMs = successful.reduce((s, r) => s + r.timeMs, 0);
		const avgMs = totalMs / successful.length;
		const maxMs = Math.max(...successful.map(r => r.timeMs));
		console.log();
		console.log('Performance Summary:');
		console.log(`Total: ${formatTime(totalMs)} | Avg: ${formatTime(avgMs)} | Max: ${formatTime(maxMs)}`);
	}
}

function formatTime(ms: number): string {
	if (ms >= 1) return `${ms.toFixed(1)}ms`;
	const us = ms * 1000;
	if (us >= 1) return `${us.toFixed(1)}μs`;
	return `${(ms * 1_000_000).toFixed(0)}ns`;
}

function formatResult(val: unknown): string {
	if (val === null || val === undefined) return 'null';
	if (val instanceof ListNode) {
		const parts: number[] = [];
		let cur: ListNode | null = val;
		while (cur) { parts.push(cur.val); cur = cur.next; }
		return '[' + parts.join(', ') + ']';
	}
	if (val instanceof TreeNode) return `TreeNode(${val.val})`;
	if (Array.isArray(val)) return '[' + val.map(formatResult).join(', ') + ']';
	return String(val);
}
