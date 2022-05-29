//
// Created by ikuta on 2020/09/17.
//

#include "Sudoku.h"

SudokuSolver::SudokuSolver()
{}

bool SudokuSolver::solve(std::vector<std::vector<int>> &ans, int row, int col) {

  if(col > this->COLS - 1){
    return true;
  }
  else if(row > this->ROWS - 1){
    return solve(ans, 0, col + 1);
  }
  else if(ans[col][row] != 0){
    return solve(ans, row + 1, col);
  }
  else{
    //数字の当てはめ
    for(int i = 1; i <= 9; i++){
      if(change_num(ans, col, row, i)){
        if(solve(ans, row + 1, col)){
          return true;
        }
      }
    }
    //どれにも当てはまらなかったものは空欄に戻す
    ans[col][row] = 0;
  }
  return false;
}

bool SudokuSolver::check_col(std::vector<std::vector<int>> &arr, int col, int num) {
  for(int i = 0; i < ROWS; i++){
    if(arr[col][i] == num) return false;
  }
  return true;
}

bool SudokuSolver::check_row(std::vector<std::vector<int>> &arr, int row, int num) {
  for(int i = 0; i < COLS; i++){
    if(arr[i][row] == num) return false;
  }
  return true;
}

bool SudokuSolver::check_3x3(std::vector<std::vector<int>> &arr, int col, int row, int num) {
  int col_base = (col / 3) * 3;
  int row_base = (row / 3) * 3;
  for(int i = 0; i < 3; i++){
    for(int j = 0; j < 3; j++){
      if(arr[col_base + i][row_base + j] == num) return false;
    }
  }
  return true;
}

bool SudokuSolver::change_num(std::vector<std::vector<int>> &arr, int col, int row, int num) {
  if(check_col(arr, col, num) && check_row(arr, row, num) && check_3x3(arr, col, row, num)){
    arr[col][row] = num;
    return true;
  }
  return false;
}


