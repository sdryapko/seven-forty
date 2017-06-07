using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenForty.GameSolver
{


	public class PlayerVariants
	{
		bool IsSevenTwoOne
		{
			get;
			set;
		}

		public List<Int32> variants7 = new List<Int32>();
		public List<Int32> variants2 = new List<Int32>();
		public List<Int32> variants1 = new List<Int32>();

		String Name
		{
			get;
			set;
		}

		String Team
		{
			get;
			set;
		}

		public PlayerVariants(String str)
		{
			str = str + "-";
			for (int i = 0; i < str.Length; ++i) if (str[i] == '(')
			{
				Name = str.Substring(0, i).Trim();
				int q = i;
				int current = 0;
				while (q < str.Length && str[q] != '/')
				{
					if (str[q] == '-')
					{
						if (variants7.Count < 7) variants7.Add(current);
					}
					if (Char.IsDigit(str[q])) current = current * 10 + str[q] - '0';
					else current = 0;
					q++;
				}
				current = 0;
				if (q < str.Length) q++;
				while (q < str.Length && str[q] != '/')
				{
					if (str[q] == '-')
					{
						if (variants2.Count < 2) variants2.Add(current);
						IsSevenTwoOne = true;
					}
					if (Char.IsDigit(str[q])) current = current * 10 + str[q] - '0';
					else current = 0;
					q++;
				}
				current = 0;
				if (q < str.Length) q++;
				while (q < str.Length)
				{
					if (str[q] == '-')
					{
						if (variants1.Count < 1) variants1.Add(current);
						IsSevenTwoOne = true;
					}
					if (Char.IsDigit(str[q])) current = current * 10 + str[q] - '0';
					else current = 0;
					q++;
				}
			}
		}

	}

}
