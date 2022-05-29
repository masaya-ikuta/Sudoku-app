//
// Created by ikuta on 2020/09/17.
// 参考:https://qiita.com/Anishishi/items/00fa13fcf0850144cae1
//

#ifndef SUDOKU_H
#define SUDOKU_H
#include <vector>

//extern "C" {
    class SudokuSolver {
    public:
        /**
         * コンストラクタ
         */
        SudokuSolver();

        /**
         * 数独を解く
         * @param ans 解答
         * @param row 注目しているマス目の列番号(0 index)
         * @param col 注目しているマス目の行番号(0 index)
         * @return 解答
         */
        bool solve(std::vector<std::vector<int>>& ans, int row = 0, int col = 0);
    private:
        //列数、行数 必要があれば変更
        const int ROWS = 9, COLS = 9;
        //col方向のチェック
        bool check_col(std::vector<std::vector<int>>& arr, int col, int num);
        //row方向のチェック
        bool check_row(std::vector<std::vector<int>>& arr, int row, int num);
        //(row,col)が含まれる3x3のチェック
        bool check_3x3(std::vector<std::vector<int>>& arr, int row, int col, int num);
        //arr[col][row]にnを当てはめようとしたとき数独のルールに沿っているかどうかを見る,従っているなら変更
        bool change_num(std::vector<std::vector<int>>& arr, int col, int row, int num);
    };
//}
#endif //SUDOKU_H