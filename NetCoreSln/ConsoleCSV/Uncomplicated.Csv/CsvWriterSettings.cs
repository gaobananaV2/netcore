﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uncomplicated.Csv
{
	public class CsvWriterSettings
	{
		internal bool Readonly { get; set; }

		/// <summary>
		/// Encoding of the file.
		/// </summary>
		public Encoding Encoding
		{
			get { return _encoding; }
			set
			{
				if (!Readonly) { _encoding = value; }
				else { throw new CsvException(string.Concat("Read only property 'CsvWriterSettings.Encoding'")); }
			}
		}
		private Encoding _encoding = null;

		/// <summary>
		/// Value to be rendered in place of null. 
		/// CANNOT CONTAIN SEPARATOR OR NEWLINE OR TEXT-QUALIFIER.
		/// Default is empty.
		/// </summary>
		public string NullValue
		{
			get { return _nullValue; }
			set
			{
				if (!Readonly)
				{
					_nullValue = value ?? string.Empty;
					ValidateSettings();
				}
				else { throw new CsvException(string.Concat("Read only property 'CsvWriterSettings.NullValue'")); }
			}
		}
		private string _nullValue = null;

		/// <summary>
		/// Character used as column separator. There is no validation so be sure to put something printable in there.
		/// Default is comma.
		/// </summary>
		public char ColumnSeparator
		{
			get { return _columnSeparator; }
			set
			{
				if (!Readonly)
				{
					_columnSeparator = value;
					ValidateSettings();
				}
				else { throw new CsvException(string.Concat("Read only property 'CsvWriterSettings.ColumnSeparator'")); }
			}
		}
		private char _columnSeparator = ',';

		/// <summary>
		/// Determine how the line should end.
		/// Unix="\n", Windows="\r\n", OldMac="\r"
		/// </summary>
		public CsvNewLineMode NewLineMode
		{
			get { return _newLineMode; }
			set
			{
				if (!Readonly) { _newLineMode = value; }
				else { throw new CsvException(string.Concat("Read only property 'CsvWriterSettings.NewLineMode'")); }
			}
		}
		private CsvNewLineMode _newLineMode = CsvNewLineMode.Windows;

		/// <summary>
		/// Character used for text qualification. There is no validation so be sure to put something printable in there.
		/// Default is double quotes.
		/// </summary>
		public char TextQualifier
		{
			get { return _textQualifier; }
			set
			{
				if (!Readonly)
				{
					_textQualifier = value;
					ValidateSettings();
				}
				else { throw new CsvException(string.Concat("Read only property 'CsvWriterSettings.TextQualifier'")); }
			}
		}
		private char _textQualifier = '"';

		/// <summary>
		/// Text qualilfication. AsNeeded means that it will be used if a cell contains the column separator 
		/// character, a new line character or the text qualifyer character.
		/// Default is Always.
		/// </summary>
		public CsvTextQualification TextQualification
		{
			get { return _textQualification; }
			set
			{
				if (!Readonly)
				{
					_textQualification = value;
					ValidateSettings();
				}
				else { throw new CsvException(string.Concat("Read only property 'CsvWriterSettings.TextQualification'")); }
			}
		}
		private CsvTextQualification _textQualification = CsvTextQualification.Always;

		public CsvWriterSettings()
		{
		}

		/// <summary>
		/// Qualifies
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		public string TextQualify(string cell)
		{
			cell = string.Concat(
				TextQualifier,
				cell.Replace(TextQualifier.ToString(), string.Concat(TextQualifier, TextQualifier)),
				TextQualifier
			);
			return cell;
		}

		/// <summary>
		/// Escapes and qualifies
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		public string ConvertCell(string cell)
		{
			if (cell == null)
			{
				return NullValue;
			}

			switch (TextQualification)
			{
				case CsvTextQualification.AsNeeded:
					if (
						cell.Contains(ColumnSeparator)
						|| cell.Contains('\r')
						|| cell.Contains('\n')
						|| cell.Contains(TextQualifier))
					{
						cell = TextQualify(cell);
					}
					break;

				case CsvTextQualification.Always:
					cell = TextQualify(cell);
					break;
			}

			return cell;
		}

		/// <summary>
		/// Obtains the appropriate end of line string.
		/// </summary>
		/// <returns></returns>
		public string GetEOL()
		{
			string eol = string.Empty;

			switch (NewLineMode)
			{
				case CsvNewLineMode.OldMac:
					eol = "\r";
					break;

				default:
				case CsvNewLineMode.Windows:
					eol = "\r\n";
					break;

				case CsvNewLineMode.Unix:
					eol = "\n";
					break;
			}

			return eol;
		}

		/// <summary>
		/// Produces the data to be written for a single row.
		/// </summary>
		/// <param name="cells"></param>
		/// <returns></returns>
		public string CreateRow(params string[] cells)
		{
			return CreateRow(cells.ToList());
		}

		/// <summary>
		/// Produces the data to be written for a single row.
		/// </summary>
		/// <param name="cells"></param>
		/// <returns></returns>
		public string CreateRow(IEnumerable<string> cells)
		{
			string row = string.Join(ColumnSeparator.ToString(), cells.Select(cell => ConvertCell(cell)));
			return row;
		}

		internal CsvWriterSettings Clone()
		{
			var clone = MemberwiseClone() as CsvWriterSettings;
			clone.Readonly = false;
			clone.Encoding = Encoding == null ? null : Encoding.Clone() as Encoding;
			return clone;
		}

		private void ValidateSettings()
		{
			CsvUtil.ValidateCsvSettings(NullValue, ColumnSeparator, TextQualification == CsvTextQualification.None ? '\0' : TextQualifier);
		}
	}

}