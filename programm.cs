using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace polyMorphisamStateAndExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            const string suffix= "Controller";
            var listofAssembly= AppDomain.CurrentDomain.GetAssemblies();
            listofAssembly.ToList().ForEach(Assembly =>
            {
                var listofTypes = Assembly.GetTypes();
                // filter all the non abstract type controller and 
                // running the 
                var listofController = listofTypes.Where(type => type.Name.EndsWith(suffix) && !type.IsAbstract);
                if (listofController.Count() > 0)
                {
                    Console.WriteLine($"the current assembly containt the controler type as follows {Assembly.FullName} ");
                    listofController.ToList().ForEach(type =>
                    {
                        Console.WriteLine($"{type.FullName}");                        
                       
                        foreach(var constructor in type.GetConstructors()) {
                            var listofparmater = constructor.GetParameters();
                            if (listofparmater.Count() == 1)
                            {
                                var parameter = listofparmater.First();
                                var paramterInstance = getDependency(parameter.ParameterType);
                                var instanceofconstructro = constructor.Invoke(new object[] { paramterInstance });
                                var methodInfo = type.GetMethod("ExecuteAsyn");
                                methodInfo.Invoke(instanceofconstructro, null);
                            }
                            else {
                                if (listofparmater.Count() == 0) {
                                    var instanceofConstructor = constructor.Invoke(null);
                                    var methodInfo = type.GetMethod("ExecuteAsyn");
                                    methodInfo.Invoke(instanceofConstructor, null);
                                }
                            }
                            

                        }

                    });
                }
            });

            Console.ReadLine();
        }

        public static void printItsDependencies(Type typeObject){
            var listofController = typeObject.GetConstructors().ToList();
            Console.WriteLine("printing its dependencies as fllows");
            Console.WriteLine("-------------------------------------");

            listofController.ForEach(constructorinfo =>
            {
                if (constructorinfo.GetParameters().Count() > 0)
                {
                    constructorinfo.GetParameters().ToList().ForEach(constructorparameter =>
                    {
                        Console.WriteLine("constructor depeneies as follows");
                        Console.WriteLine($"parameter type {constructorparameter.ParameterType.FullName} and paramter name as follows{constructorparameter.Name}");
                        printItsDependencies(constructorparameter.ParameterType);
                    });
                }
            });
        }

        public static object getDependency(Type typeobject) {
            // here this type contain the constructor which is parameter less...
            if (typeobject.GetConstructors().Count()==1 && typeobject.GetConstructors().First().GetParameters().Count() == 0) {
                return typeobject.GetConstructors().First().Invoke(null);
            }

            var listOfconstructor = typeobject.GetConstructors();
            foreach(var constructor in listOfconstructor) {
              var listofParmater = constructor.GetParameters();
                if (listofParmater.Count() == 1) {
                    var denepenctType = listofParmater.Single().ParameterType;
                    var parameterInstance = getDependency(denepenctType);
                    return constructor.Invoke(new object[] { parameterInstance });
                }
            }

            throw new Exception("please provide the constructor which possess only one parameter");
        }
    }
}
