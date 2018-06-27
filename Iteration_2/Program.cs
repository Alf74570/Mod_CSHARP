//using System;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;
using MyLibrary;


namespace Iteration_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiRequest apiRequest = new ApiRequest();

            List<Lines> resultGetLines = apiRequest.getLines();

            List<string> linesSsDoublons = new List<string>();

            foreach (Lines line in resultGetLines)
            {
                if (!linesSsDoublons.Contains(line.id))
                {
                    Console.ForegroundColor = Color.White;
                    Console.WriteLine($"ID de l'arrêt: {line.id}");
                    Console.WriteLine($"Nom de l'arrêt: {line.name}");
                    linesSsDoublons.Add(line.id);
                }

                List<string> linesSsDoublons2 = new List<string>();

                foreach (string lineId in line.lines)
                {
                    if (!linesSsDoublons2.Contains(lineId))
                    {
                        //Console.WriteLine($"Numéro de la ligne: {lineId}");
                        linesSsDoublons2.Add(lineId);

                        List<LinesDescription> resultGetLinesDescription = apiRequest.getLinesDescription(lineId);

                        foreach (LinesDescription linesDescription in resultGetLinesDescription)
                        {
                            var colorback = ColorTranslator.FromHtml($"#{linesDescription.color}");

                            Console.ForegroundColor = colorback;
                            Console.WriteLine($"Numéro de ligne : {linesDescription.shortName}");
                            Console.ForegroundColor = colorback;
                            Console.WriteLine($"Nom de la ligne : {linesDescription.longName}");
                            Console.ForegroundColor = colorback;
                            Console.WriteLine($"Type de ligne : {linesDescription.mode}");
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
