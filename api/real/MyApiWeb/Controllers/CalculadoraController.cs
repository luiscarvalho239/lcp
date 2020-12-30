using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MyApiWeb.Controllers
{
  [Route("api/calculadora")]
  [ApiController]
  public class CalculadoraController : ControllerBase
  {
    [HttpGet("adição/{num1}/{num2}")]
    public double ObterAdição(double num1 = 0, double num2 = 0, int dec = 0)
    {
      return Math.Round(num1 + num2, dec);
    }

    [HttpGet("subtração/{num1}/{num2}")]
    public double ObterSubtração(double num1 = 0, double num2 = 0, int dec = 0)
    {
      return Math.Round(num1 - num2, dec);
    }

    [HttpGet("multiplicação/{num1}/{num2}")]
    public double ObterMultiplicação(double num1 = 0, double num2 = 0, int dec = 0)
    {
      return Math.Round(num1 * num2, dec);
    }

    [HttpGet("divisão/{num1}/{num2}")]
    public double ObterDivisão(double num1 = 1, double num2 = 1, int dec = 0)
    {
      return Math.Round(num1 / num2, dec);
    }

    [HttpGet("média")]
    public double ObterMédia([FromQuery] int[] numx)
    {
      return Average(numx);
    }

    [HttpGet("média/notas")]
    public IActionResult ObterMédiaAlunos()
    {
      int[][] aryNotas = {
        new int[] { 12, 14, 18 },
        new int[] { 11, 13, 17 }
      };
      var listaAlunos = new List<AlunosInfo>() {
        new AlunosInfo() {
          Nome = "Luis",
          Testes = new List<AlunosTestes>() {
            new AlunosTestes() {
              Notas = aryNotas[0],
              Media = Average(aryNotas[0]) + "%",
              Classificacao = ClassificationGrade(Average(aryNotas[0]))
            }
          }
        },
        new AlunosInfo() {
          Nome = "Joao",
          Testes = new List<AlunosTestes>() {
            new AlunosTestes() {
              Notas = aryNotas[1],
              Media = Average(aryNotas[1]) + "%",
              Classificacao = ClassificationGrade(Average(aryNotas[1]))
            }
          }
        }
      };
      return Ok(listaAlunos);
    }

    private double Average(int[] numx)
    {
      int soma = 0;
      double res;

      for (var x = 0; x < numx.Length; x++)
      {
        soma += numx[x];
      }

      res = (double)soma / numx.Length;

      return Math.Round(res, 2);
    }

    private string ClassificationGrade(double res = 10)
    {
      string strRes = "";

      if (res <= 4)
      {
        strRes = "Abismal";
      }
      else if(res > 4 && res <= 9)
      {
        strRes = "Insuficiente";
      }
      else if(res > 9 && res <= 12)
      {
        strRes = "Suficiente";
      }
      else if (res > 13 && res <= 15)
      {
        strRes = "Bom";
      }
      else if (res > 15 && res <= 19)
      {
        strRes = "Muito Bom";
      }
      else
      {
        strRes = "Excelente";
      }

      return strRes;
    }

    public class AlunosInfo {
      public string Nome { get; set; }
      public List<AlunosTestes> Testes { get; set; }
    }

    public class AlunosTestes
    {
      public int[] Notas { get; set; }
      public string Media { get; set; }
      public string Classificacao { get; set; }
    }
  }
}
