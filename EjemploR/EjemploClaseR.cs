using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDotNet;

namespace EjemploR
{
    class EjemploClaseR
    {
        public decimal resultado;
        public EjemploClaseR()
        {
            string result;

            string input;
            REngine engine;


            //init the R engine            
            REngine.SetEnvironmentVariables();
            engine = REngine.GetInstance();
            engine.Initialize();

            //input
           
            input = "5*3+1-3";

            //calculate
            CharacterVector vector = engine.Evaluate(input).AsCharacter();
            result = vector[0];

            //clean up
            engine.Dispose();

            //output
            resultado = decimal.Parse(result);
        
        }

    }

}
