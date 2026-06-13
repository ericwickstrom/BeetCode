import { Problem } from '../framework/problem';
import { TestCase } from '../framework/types';

export class Problem001 extends Problem {
	get number() { return 1; }
	get title() { return 'Two Sum'; }
	get difficulty() { return 'Easy'; }
	get description() {
		return (
			'Given an array of integers nums and an integer target, return indices of the two numbers that add up to target.\n\n' +
			'You may assume that each input would have exactly one solution, and you may not use the same element twice.\n\n' +
			'You can return the answer in any order.\n\n' +
			'Example 1:\n' +
			'  Input: nums = [2,7,11,15], target = 9\n' +
			'  Output: [0,1]\n\n' +
			'Example 2:\n' +
			'  Input: nums = [3,2,4], target = 6\n' +
			'  Output: [1,2]\n\n' +
			'Example 3:\n' +
			'  Input: nums = [3,3], target = 6\n' +
			'  Output: [0,1]'
		);
	}

	getTestCases(): TestCase[] {
		return [
			new TestCase('Example 1', [[2, 7, 11, 15], 9], [0, 1]),
			new TestCase('Example 2', [[3, 2, 4], 6], [1, 2]),
			new TestCase('Example 3', [[3, 3], 6], [0, 1]),
		];
	}

	executeSolution(inputs: unknown[]): unknown {
		return this.twoSum(inputs[0] as number[], inputs[1] as number);
	}

	// YOUR SOLUTION GOES HERE
	twoSum(nums: number[], target: number): number[] {
		throw new Error('Not implemented');
	}
}
