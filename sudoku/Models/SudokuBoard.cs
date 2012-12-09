using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku
{
    class SudokuBoard
    {
        #region members

        private List<SudokuCell> elements = new List<SudokuCell> { };//store by row major
        private List<List<SudokuCell>> rows = new List<List<SudokuCell>> { };
        private List<List<SudokuCell>> cols = new List<List<SudokuCell>> { };
        private List<List<SudokuCell>> boxs = new List<List<SudokuCell>> { };

        public bool isSolved { get { return this.IsSolved(); } }

        #endregion

        #region constructers

        public SudokuBoard()
        {
            this.elements.Clear();
            for (int x = 0; x < 81; x++)
                this.elements.Add(new SudokuCell());
            this.AssignHelpers();
        }

        public SudokuBoard(string input)
        {
            elements.Clear();
            foreach (char c in input)
                this.elements.Add(new SudokuCell(c));
            while (this.elements.Count < 81)
                this.elements.Add(new SudokuCell());
            while (this.elements.Count > 81)
                this.elements.RemoveAt(81);
            this.AssignHelpers();
        }

        public SudokuBoard(SudokuBoard other)
        {
            elements.Clear();
            SudokuCell temp;
            foreach (SudokuCell cell in other.elements)
            {
                temp = new SudokuCell();
                temp.Choices = cell.Choices;
                this.elements.Add(temp);
            }
            this.AssignHelpers();
        }

        #endregion

        #region methods

        private void AssignHelpers()
        {
            this.rows.Clear();
            this.cols.Clear();
            this.boxs.Clear();
            for (int x = 0; x < 9; x++)
            {
                this.rows.Add(new List<SudokuCell> { });
                this.cols.Add(new List<SudokuCell> { });
                this.boxs.Add(new List<SudokuCell> { });
            }
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    this.rows[x].Add(elements[y + (x * 9)]);
                    this.cols[y].Add(elements[y + (x * 9)]);
                }
            }
            for (int b = 0; b < 3; b++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        boxs[(b * 3) + 0].Add(elements[(b * 27) + (9 * x) + y + 0]);
                        boxs[(b * 3) + 1].Add(elements[(b * 27) + (9 * x) + y + 3]);
                        boxs[(b * 3) + 2].Add(elements[(b * 27) + (9 * x) + y + 6]);
                    }
                }
            }
        }

        public bool IsSolved()
        {
            bool solved = true;
            for (int x = 0; x < 9; x++)
            {
                solved = solved && IsCellListCompleted(rows[x]);
                solved = solved && IsCellListCompleted(cols[x]);
                solved = solved && IsCellListCompleted(boxs[x]);
            }
            return solved;
        }

        private bool IsCellListCompleted(List<SudokuCell> cells)
        {
            bool[] temp = new bool[10];
            bool output;
            for (int x = 0; x < 10; x++)
                temp[x] = false;
            foreach (SudokuCell cell in cells)
            {
                temp[cell.GetValue()] = true;
            }
            if (temp[0] == true)
                return false;
            else
            {
                output = true;
                for (int x = 1; x < 10; x++)
                    output = output && temp[x];
                return output;
            }
        }

        public void SetTestData()
        {
            SudokuBoard temp = new SudokuBoard("100007090030020008009600500005300900010080002600004000300000010040000007007000300");
            SudokuBoard temp2 = new SudokuBoard("000000000030020008009600500005300900010080002600004000300000010040000007007000300");
            for (int x = 0; x < 81; x++)
            {
                this.elements[x].Choices = temp.elements[x].Choices;
            }
        }

        public void Solve()
        {
            //this.SetTestData();
            this.SolveComplex();
            this.SolveBrute();
        }

        private void SolveSimple()
        {
            bool changing = true;
            while (changing)
            {
                changing = EliminateFromKnownValues() || SetByExclusivity();
            }
        }

        private void SolveComplex()
        {
            List<int> options;
            SudokuBoard temp;
            SudokuBoard newBoard;
            bool changed = true;
            this.SolveSimple();
            while (changed == true)
            {
                changed = false;
                for (int x = 0; x < 81 && this.IsSolved() == false; x++)
                {
                    if (this.elements[x].IsSingleton() == false)
                    {
                        newBoard = null;
                        options = this.elements[x].ListChoices();
                        foreach (int option in options)
                        {
                            temp = this.DeepCopy();
                            temp.elements[x].SetValue(option);
                            temp.SolveSimple();
                            newBoard = (newBoard == null) ? temp : (SudokuBoard.OrBoardChoices(newBoard, temp));
                        }
                        newBoard.SolveSimple();
                        for (int y = 0; y < 81; y++)
                        {
                            if (this.elements[y].Choices != newBoard.elements[y].Choices)
                            {
                                changed = true;
                                this.elements[y] = newBoard.elements[y];
                                this.AssignHelpers();
                            }
                        }
                    }
                }
            }
        }

        private void SolveBrute()
        {
            List<int> options;
            SudokuBoard temp;
            this.SolveComplex();
            for (int x = 0; x < 81 && this.IsSolved() == false; x++)
            {
                if (this.elements[x].IsSingleton() == false)
                {
                    options = this.elements[x].ListChoices();
                    foreach (int option in options)
                    {
                        if (this.IsSolved() == false)
                        {
                            temp = this.DeepCopy();
                            temp.elements[x].SetValue(option);
                            temp.SolveComplex();
                            if (temp.IsSolved() == false)
                            {
                                temp.SolveBrute();
                            }
                            if (temp.IsSolved())
                            {
                                for (int y = 0; y < 81; y++)
                                    this.elements[y] = temp.elements[y];
                                this.AssignHelpers();
                            }
                        }
                    }
                }
            }
        }

        private static SudokuBoard OrBoardChoices(SudokuBoard b1, SudokuBoard b2)
        {
            SudokuBoard temp = new SudokuBoard();
            for (int x = 0; x < 81; x++)
            {
                temp.elements[x].Choices = b1.elements[x].Choices | b2.elements[x].Choices;
            }
            return temp;
        }

        private bool EliminateByGrouping()
        {
            bool changed = false;
            for (int x = 0; x < 9; x++)
            {
                changed = changed || EliminateByGroupingRowHelper(x)||EliminateByGroupingColHelper(x);
            }


            return changed;
        }

        private bool EliminateByGroupingRowHelper(int row)
        {
            bool changed = false;
            List<List<SudokuCell>> values = new List<List<SudokuCell>>() { };
            for (int x = 0; x < 10; x++)
                values.Add(new List<SudokuCell>() { });
            foreach (SudokuCell cell in this.rows[row])
            {
                cell.ListChoices().ForEach((c) => values[c].Add(cell));
            }
            for (int x = 0; x < 10; x++)
            {
                if (values[x].Count <=1)
                    values[x] = null;
            }
            for (int x = 1; x < 10; x++)
            {
                if (values[x] != null && values[x].Count <= 3)
                {
                    bool sameBox = true;
                    int rowIndex, colIndex, boxIndex, boxIndexCurrent;
                    this.GetPosition(values[x][0], out rowIndex, out colIndex, out boxIndex);
                    foreach (SudokuCell cell in values[x])
                    {
                        this.GetPosition(cell, out rowIndex, out colIndex, out boxIndexCurrent);
                        sameBox = sameBox && (boxIndexCurrent == boxIndex);
                    }
                    if (sameBox)
                    {
                        foreach (SudokuCell cell in this.boxs[boxIndex])
                        {
                            if (values[x].Contains(cell) == false && cell.CanBe(x))
                            {
                                cell.EliminateChoice(x);
                                changed = true;
                            }
                        }
                    }

                }
            }

            return changed;
        }

        private bool EliminateByGroupingColHelper(int col)
        {
            bool changed = false;
            List<List<SudokuCell>> values = new List<List<SudokuCell>>() { };
            for (int x = 0; x < 10; x++)
                values.Add(new List<SudokuCell>() { });
            foreach (SudokuCell cell in this.cols[col])
            {
                cell.ListChoices().ForEach((c) => values[c].Add(cell));
            }
            for (int x = 0; x < 10; x++)
            {
                if (values[x].Count <=1)
                    values[x] = null;
            }
            for (int x = 1; x < 10; x++)
            {
                if (values[x] != null && values[x].Count <= 3)
                {
                    bool sameBox = true;
                    int rowIndex, colIndex, boxIndex, boxIndexCurrent;
                    this.GetPosition(values[x][0], out rowIndex, out colIndex, out boxIndex);
                    foreach (SudokuCell cell in values[x])
                    {
                        this.GetPosition(cell, out rowIndex, out colIndex, out boxIndexCurrent);
                        sameBox = sameBox && (boxIndexCurrent == boxIndex);
                    }
                    if (sameBox)
                    {
                        foreach (SudokuCell cell in this.boxs[boxIndex])
                        {
                            if (values[x].Contains(cell) == false && cell.CanBe(x))
                            {
                                cell.EliminateChoice(x);
                                changed = true;
                            }
                        }
                    }

                }
            }

            return changed;
        }

        private bool SetByExclusivity()
        {
            bool changed = false;
            for (int x = 0; x < 9; x++)
            {
                for (int value = 1; value <= 9; value++)
                {
                    changed = SetByExclusivityList(value, rows[x]) || changed;
                    changed = SetByExclusivityList(value, cols[x]) || changed;
                    changed = SetByExclusivityList(value, boxs[x]) || changed;
                }
            }
            return changed;
        }

        private bool SetByExclusivityList(int value, List<SudokuCell> cells)
        {
            int count = 0;
            SudokuCell cellToChange=null;
            foreach (SudokuCell cell in cells)
            {
                if (cell.CanBe(value))
                {
                    count++;
                    cellToChange = cell;
                }
            }
            if (count == 1 && cellToChange != null && cellToChange.IsSingleton() == false)
            {
                cellToChange.SetValue(value);
                return true;
            }
            return false;
        }
        
        private bool EliminateFromKnownValues()
        {
            bool changed = false;
            int value, row, col, box;
            for (int x = 0; x < 81; x++)
            {
                if (elements[x].IsSingleton()==true)
                {
                    value = elements[x].GetValue();
                    this.GetPosition(x, out row, out col, out box);
                    if (EliminateChoiceFromList(value, this.rows[row]) || EliminateChoiceFromList(value, this.cols[col]) || EliminateChoiceFromList(value, this.boxs[box]))
                        changed = true;
                }
            }
            return changed;
        }

        private bool EliminateChoiceFromList(int value, List<SudokuCell> cells)
        {
            bool changed = false;
            foreach (SudokuCell cell in cells)
            {
                if (cell.IsSingleton() == false && cell.CanBe(value))
                {
                    cell.EliminateChoice(value);
                    if(cell.IsSingleton()==true)
                        changed = true;
                }
            }
            return changed;
        }

        private void GetPosition(SudokuCell cell, out int row, out int col, out int box)
        {
            row = 0; col = 0; box = 0;
            for (int x = 0; x < 9; x++)
            {
                if (this.rows[x].Contains(cell))
                    row = x;
            }
            for (int x = 0; x < 9; x++)
            {
                if (this.cols[x].Contains(cell))
                    col = x;
            }
            for (int x = 0; x < 9; x++)
            {
                if (this.boxs[x].Contains(cell))
                    box = x;
            }
        }

        private void GetPosition(int num, out int row, out int col, out int box)
        {
            row = num / 9;
            col = num - (row * 9);
            box = 0;
            if (col < 3)
                box = 0;
            else if (col > 5)
                box = 2;
            else
                box = 1;

            if (row < 3)
                box += 0;
            else if (row > 5)
                box += 6;
            else
                box += 3;
        }

        public bool IsEqualTo(SudokuBoard other)
        {
            for (int x = 0; x < 81; x++)
            {
                if (this.elements[x].Choices != other.elements[x].Choices)
                    return false;
            }
            return true;
        }

        public SudokuBoard DeepCopy()
        {
            return new SudokuBoard(this);
        }
        
        public override string ToString()
        {
            string temp = "";
            foreach (SudokuCell cell in this.elements)
                temp += cell.ToString();
            return temp;
        }

        #endregion
    }
}
