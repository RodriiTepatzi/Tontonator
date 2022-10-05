﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Tontonator.Core.Helpers;
using Tontonator.Models.Enums;

namespace Tontonator.Models
{
	internal class Question : IQuestion
	{
		public string QuestionName { get; set; }
		public string QuestionCategory { get; set; }
		public string[] QuestionOptions { get => new string[] { "Si", "No", "Probablemente", "Probablemente no", "No sé" }; }
		public bool IsCorrect { get; set; }
		public QuestionOption QuestionOption { get; set; }
		public Question(string questionName, string questionCategory)
		{
			this.QuestionName = questionName;
			this.QuestionCategory = questionCategory;
		}

		public void ShowOptions()
		{
			var counter = 1;
			foreach (var option in QuestionOptions) 
			{
				Console.WriteLine(counter + ". " + option);
				counter++;
			}
		}

		public void EvaluateOption(string? option)
		{
			var opt = 0;

			if (!string.IsNullOrEmpty(option))
			{
				if (option.Length == 1)
				{
					if (char.IsDigit(option[0]))
					{
						opt = int.Parse(option);

						Console.Clear();

						switch (opt)
						{
							case 1:
								QuestionOption = QuestionOption.Si;
								IsCorrect = true;
								break;
							case 2:
								QuestionOption = QuestionOption.No;
								IsCorrect = true;
								break;
							case 3:
								QuestionOption = QuestionOption.Probablemente;
								IsCorrect = true;
								break;
							case 4:
								QuestionOption = QuestionOption.ProbablementeNo;
								IsCorrect = true;
								break;
							case 5:
								QuestionOption = QuestionOption.Nose;
								IsCorrect = true;
								break;
							default:
								MessageHelper.WriteError("ERROR: Ingrese un valor valido");
								break;
						}
					}
					else
					{
						Console.Clear();
						MessageHelper.WriteError("ERROR: Ingrese un valor númerico");
					}
				}
				else
				{
					Console.Clear();
					MessageHelper.WriteError("ERROR: Ingrese un valor valido");
				}
			}
			else
			{
				Console.Clear();
				MessageHelper.WriteError("ERROR: El campo no puede estar vacio.");
			}
		}
	}
}
