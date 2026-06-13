export class ListNode {
	val: number;
	next: ListNode | null;
	constructor(val = 0, next: ListNode | null = null) {
		this.val = val;
		this.next = next;
	}
}

export class TreeNode {
	val: number;
	left: TreeNode | null;
	right: TreeNode | null;
	constructor(val = 0, left: TreeNode | null = null, right: TreeNode | null = null) {
		this.val = val;
		this.left = left;
		this.right = right;
	}
}

export class TestCase {
	name: string;
	input: unknown[];
	expected: unknown;
	constructor(name: string, input: unknown[], expected: unknown) {
		this.name = name;
		this.input = input;
		this.expected = expected;
	}
}
