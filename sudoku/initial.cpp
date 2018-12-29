
#include "stdafx.h"

int origin[40320][9] = { 0 };	 
int init[9] = { 4, 5, 6, 7, 8, 9, 1, 2, 3 };// 第1位根据学号要求存放4

int count = 0;

inline void swap(int& a, int& b)
{
	int temp = a;	 a = b;	b = temp;
}

//递归求取全排列
void permutation(int offset)
{
	if (offset == 8) {
		for (int i = 0; i<9; i++) {
			origin[count][i] = init[i];
		}
		count++;
		return;
	}
	for (int i = offset; i<9; i++) {
		swap(init[i], init[offset]);
		permutation(offset + 1);
		swap(init[i], init[offset]);
	}
}

void initial_origin()
{
	count = 0;
	permutation(1);
}
