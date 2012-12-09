using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku
{
    class SudokuCell
    {
        #region members

        public int Choices;
        
        #endregion

        #region constructers

        public SudokuCell()
        {
            this.SetValue(0);
        }
        
        public SudokuCell(int num)
        {
            this.SetValue(num);
        }

        public SudokuCell(char c)
        {
            int num = char.IsDigit(c) ? ((int)char.GetNumericValue(c)) : 0;
            this.SetValue(num);
        }

        #endregion

        #region methods

        public List<int> ListChoices()
        {
            List<int> temp = new List<int> { };
            for (int x = 1; x <= 9; x++)
            {
                if (this.CanBe(x))
                    temp.Add(x);
            }
            return temp;
        }

        public bool IsSingleton()
        {
            return Choices == (((~Choices) + 1) & Choices);
        }

        public bool CanBe(int value)
        {
            if (value > 0 && value < 10)
                return (this.Choices & (1 << (value - 1))) != 0;
            else
                return false;
        }

        public int GetValue()
        {
            int value = 0;
            if (this.IsSingleton() == false)
                return 0;
            else
            {
                while (this.Choices != (1 << value))
                    value++;
                return value + 1;
            }
        }

        public void SetValue(int x)
        {
            if (x < 1 || x > 9)
                Choices = 0x1ff;
            else
                Choices = 1 << (x - 1);
        }

        public void EliminateChoice(int num)
        {
            if (num > 0)
                Choices = Choices & ~(1 << (num - 1));         
        }

        public SudokuCell DeepCopy()
        {
            SudokuCell temp = new SudokuCell();
            temp.Choices = this.Choices;
            return temp;
        }

        public override string ToString()
        {
            return this.GetValue().ToString();
        }

        #endregion
    }
}
