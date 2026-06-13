import { ListNode, TreeNode, TestCase } from './types';

export abstract class Problem {
	abstract get number(): number;
	abstract get title(): string;
	abstract get difficulty(): string;
	abstract get description(): string;

	abstract getTestCases(): TestCase[];
	abstract executeSolution(inputs: unknown[]): unknown;

	displayProblemInfo(): void {
		console.log(`Problem ${this.number}: ${this.title}`);
		console.log(`Difficulty: ${this.difficulty}`);
		console.log();
		console.log(this.description);
		console.log();
	}

	isSolved(): boolean {
		try {
			const testCases = this.getTestCases();
			if (testCases.length === 0) return false;
			for (const tc of testCases) {
				const result = this.executeSolution(tc.input);
				if (!this.areEqual(result, tc.expected)) return false;
			}
			return true;
		} catch {
			return false;
		}
	}

	areEqual(actual: unknown, expected: unknown): boolean {
		if (actual === null && expected === null) return true;
		if (actual === null || expected === null) return false;

		if (actual instanceof ListNode && expected instanceof ListNode) {
			return linkedListsEqual(actual, expected);
		}
		if (actual instanceof TreeNode && expected instanceof TreeNode) {
			return treesEqual(actual, expected);
		}
		if (Array.isArray(actual) && Array.isArray(expected)) {
			if (actual.length !== expected.length) return false;
			return actual.every((v, i) => this.areEqual(v, (expected as unknown[])[i]));
		}

		return actual === expected;
	}

	protected createLinkedList(values: number[]): ListNode | null {
		if (values.length === 0) return null;
		const head = new ListNode(values[0]);
		let cur = head;
		for (let i = 1; i < values.length; i++) {
			cur.next = new ListNode(values[i]);
			cur = cur.next;
		}
		return head;
	}

	protected linkedListToArray(head: ListNode | null): number[] {
		const out: number[] = [];
		let cur = head;
		while (cur !== null) { out.push(cur.val); cur = cur.next; }
		return out;
	}

	protected createTree(values: (number | null)[]): TreeNode | null {
		if (values.length === 0 || values[0] === null) return null;
		const root = new TreeNode(values[0]);
		const queue: TreeNode[] = [root];
		let i = 1;
		while (i < values.length && queue.length > 0) {
			const cur = queue.shift()!;
			if (i < values.length && values[i] !== null) {
				cur.left = new TreeNode(values[i] as number);
				queue.push(cur.left);
			}
			i++;
			if (i < values.length && values[i] !== null) {
				cur.right = new TreeNode(values[i] as number);
				queue.push(cur.right);
			}
			i++;
		}
		return root;
	}
}

function linkedListsEqual(a: ListNode | null, b: ListNode | null): boolean {
	while (a !== null && b !== null) {
		if (a.val !== b.val) return false;
		a = a.next;
		b = b.next;
	}
	return a === null && b === null;
}

function treesEqual(a: TreeNode | null, b: TreeNode | null): boolean {
	if (a === null && b === null) return true;
	if (a === null || b === null) return false;
	return a.val === b.val && treesEqual(a.left, b.left) && treesEqual(a.right, b.right);
}
