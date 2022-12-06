/*
 * Create by elang
 * 2017-02-11
 */

using System;
using System.IO;
using LitJson;
using UnityEngine;

namespace Json2CSharp
{
	public class GenClassFromJson
	{
		private string outputFilePath;

		private const string propertyTypeDesc = "{get; set;}\n";

		public GenClassFromJson(string jsonStr, string className)
		{
			outputFilePath = "Assets/JsonToCs/" + className + ".cs";
			if (!Directory.Exists( "Assets/JsonToCs/")) {
				Directory.CreateDirectory( "Assets/JsonToCs/");
			}
			if (File.Exists(outputFilePath))
			{
				File.Delete(outputFilePath);
			}

			AppendNameSpace("using LitJson;\n\n");


			Debug.Log(jsonStr);
			ParseJson(jsonStr, className);

			AppendParseJsonClass(className);
		}

		private string GetValueType(JsonReader reader)
		{
			return reader.Value != null ? reader.Value.GetType().ToString() : "";
		}

		public void ParseJson(string jsonStr, string rootName)
		{
			JsonReader reader = new JsonReader(jsonStr);

			ParseJsonNode(reader, rootName);
		}

		public void ParseJsonNode(JsonReader reader, string rootName)
		{
			string classDesc = string.Empty;
			string prePropertyValue = string.Empty;

			do
			{
				//Console.WriteLine("{0,14} {1,10} {2,16}", reader.Token, reader.Value, GetValueType(reader));

				if (reader.Token == JsonToken.ObjectStart)
				{
					if (string.IsNullOrEmpty(classDesc))
					{
						classDesc = "\n[System.Serializable]\npublic class " + rootName + " {\n\n";
					}
					else
					{
						string objName = ToHumpFormat(prePropertyValue);

						classDesc += "\tpublic " + objName + " " + prePropertyValue + propertyTypeDesc;

						ParseJsonNode(reader, objName);
					}
				}
				else if (reader.Token == JsonToken.ObjectEnd)
				{
					classDesc += "\n} \n";

					AppendToLocalFile(classDesc);

					return;
				}
				else if (reader.Token == JsonToken.PropertyName)
				{
					prePropertyValue = reader.Value.ToString();
				}
				else if (reader.Token == JsonToken.ArrayStart)
				{
					reader.Read();

					if (reader.Token == JsonToken.ObjectStart)
					{
						string objName = ToHumpFormat(prePropertyValue);
						classDesc += "\tpublic " + objName + "[] " + prePropertyValue + propertyTypeDesc;

						ParseJsonNode(reader, objName);
					}
				}
				else if (reader.Token == JsonToken.ArrayEnd)
				{
					//nothing to do
				}
				else if (reader.Token == JsonToken.Int)
				{
					classDesc += "\tpublic int " + prePropertyValue + " {get; set;}\n";
				}
				else if (reader.Token == JsonToken.Long || 
				         reader.Token == JsonToken.Boolean || 
				         reader.Token == JsonToken.Double || 
				         reader.Token == JsonToken.String
				        )
				{
					string type = GetValueType(reader);

					string[] typeParts = type.Split('.');

					classDesc += "\tpublic " + typeParts[typeParts.Length - 1].ToLower() + "  " + prePropertyValue + propertyTypeDesc;
				}

			} while (reader.Read());

			Console.WriteLine("Json to csharp complete!");
		}

		private void AppendParseJsonClass(string className)
		{
			string parseClassDesc = "\n\npublic class " + className + "Parser {\n\n";

			parseClassDesc += "\tpublic " + className + " Data {get; private set;}\n\n";

			parseClassDesc += "\tpublic " + className + "Parser(string jsonStr) {\n \t\tParse(jsonStr);  \n\t}\n\n";

			parseClassDesc += "\tprivate void Parse(string jsonStr) {\n\t\tData = JsonMapper.ToObject<" + className + ">(jsonStr);  \n\t}\n";

			parseClassDesc += "\n }";

			AppendToLocalFile(parseClassDesc);
		}

		void AppendNameSpace(string namespaceStr)
		{
			AppendToLocalFile(namespaceStr);

			//TODO
		}

		private string ToHumpFormat(string value)
		{
			return value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
		}

		private void AppendToLocalFile(string classDesc)
		{
			File.AppendAllText(outputFilePath, classDesc);
		}
	}
}
