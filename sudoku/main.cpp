/// <summary> 
///	功能：1.实现向文件输出1 ~ 100 0000个数独终局
///       2.实现从指定文件读取数独残局，解数独 
///       3.在命令行输入-c 数字 生成相应数量的数独，并将其存放在sudoku.txt文件中
///       4.在命令行输入-s 文件名 解该文件中的数独，并将结果保存在该文件中
/// </summary> 
///	<student_number> 1120161757 </student_number> 

#include "stdafx.h"
using namespace std;
#pragma warning(disable:4996)


int main(int argc, char* argv[])
{
	if (strcmp(argv[1], "-c") == 0) {
		int num = change_num(argv[2]);

		if (num == -1)
			printf("\n请正确输入\n");
		else if (num == -2)
			printf("\n输入超过最大范围!\n");
		else if (num == -3)
			printf("\n输入超过最大范围!\n");
		else if (num == 0)
			printf("\n请正确输入\n");
		else {
			if (origin[0][0] == 0) {
				initial_origin();
			}

			int examine = create_sudoku(num);

			if (examine == -1)
				printf("\nProgram Execution Error: Wrong on creation of the end of sudoku.\n");
		}
	}
	else if (strcmp(argv[1], "-s") == 0) {
		FILE *fp;
		fp = fopen(argv[2], "r");
		if (fp == NULL) {
			printf("\n打开文件失败\n");
		}
		solve_sudoku(fp);
	}

	return 0;
}
