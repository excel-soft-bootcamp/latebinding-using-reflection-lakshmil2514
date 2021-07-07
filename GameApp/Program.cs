using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    //Named Constants
    //Constant Value is - int
    public enum Options
    {
        BASIC = 1, INTERMEDIATE, ADVANCED
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Guess Game");

            // string message = string.Format("Enter Your Choice {0}->Basic , {1}->Intermediate ,{2}->Advanced",Options.BASIC,Options.INTERMEDIATE,Options.ADVANCED);// 1->Basic,2->Intermediate
            //String Interpollation 
            
                string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
                Console.WriteLine(displayMessage);
                Options _choice = (Options)Int32.Parse(Console.ReadLine());
            try 
            { 

                switch (_choice)
                {
                    case Options.BASIC:
                        Console.WriteLine("Basic Level");
                        //Use Reflection  
                        //Assembly Load
                        System.Reflection.Assembly basicLevelLib =
          System.Reflection.Assembly.LoadFile(@"C:\Users\lakshmi.l\source\repos\latebinding-using-reflection-lakshmil2514-main\GameApp\bin\Debug\BasicLevelLibs.dll");
                        // Search For Class - BasicLevelType
                        System.Type basicLevelTypeClassRef = basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                        if (basicLevelTypeClassRef != null)
                        {
                            if (basicLevelTypeClassRef.IsClass)
                            {
                                //Instantiate Type
                                //BasicLevelLib.BasicLevelType objref=new BasicLevelLib.BasicLevelType() ; Early Binding
                                Object objRef = System.Activator.CreateInstance(basicLevelTypeClassRef); //LateBinding Code
                                                                                                         //Discove Method
                                System.Reflection.MethodInfo _methodRef = basicLevelTypeClassRef.GetMethod("Play");
                                if (!_methodRef.IsStatic)
                                {
                                    //Invoke NonStatic Method
                                    // string Play(string playerName, int earlierPoints){}
                                    //object result=  _methodRef.Invoke(objRef, new object[] {"Tom",20 });
                                    object result = _methodRef.Invoke(objRef, new object[] {"sham",25 });
                                    Console.WriteLine(result.ToString());
                                }

                            }

                        }
                        break;
                    case Options.INTERMEDIATE:
                        Console.WriteLine("Intermediate Level");
                        System.Reflection.Assembly intermediateLevelLib =
         System.Reflection.Assembly.LoadFile(@"C:\Users\lakshmi.l\source\repos\latebinding-using-reflection-lakshmil2514-main\GameApp\bin\Debug\IntermediateLevelLibs.dll");
                        System.Type intermediateLevelTypeClassRef = intermediateLevelLib.GetType("IntermediateLevelLib.IntermediateLevelType");
                        if (intermediateLevelTypeClassRef != null)
                        {

                            if (intermediateLevelTypeClassRef.IsClass)
                            {
                                Object objectRef = System.Activator.CreateInstance(intermediateLevelTypeClassRef);
                                System.Reflection.MethodInfo _methodRef = intermediateLevelTypeClassRef.GetMethod("Play");
                                if (!_methodRef.IsStatic)
                                {
                                    object result = _methodRef.Invoke(objectRef, new object[] {"Ram",10 });
                                    Console.WriteLine(result.ToString());
                                }
                            }
                        }
                        break;
                    case Options.ADVANCED:
                        Console.WriteLine("Advanced Level");
                        System.Reflection.Assembly advancedLevelLib =
         System.Reflection.Assembly.LoadFile(@"C:\Users\lakshmi.l\source\repos\latebinding-using-reflection-lakshmil2514-main\GameApp\bin\Debug\AdvancedLevelLibs.dll");
                        System.Type advancedLevelTypeClassRef = advancedLevelLib.GetType("AdvancedlLib.AdvancedLevelType");
                        if (advancedLevelTypeClassRef != null)
                        {

                            if (advancedLevelTypeClassRef.IsClass)
                            {
                                Object objectRef = System.Activator.CreateInstance(advancedLevelTypeClassRef);
                                System.Reflection.MethodInfo _methodRef = advancedLevelTypeClassRef.GetMethod("Play");
                                if (!_methodRef.IsStatic)
                                {
                                    object result = _methodRef.Invoke(objectRef, new object[] {"Toe",45 });
                                    Console.WriteLine(result.ToString());
                                }
                            }
                        }
                        break;
                   


                }

            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
           
           
        }
    }
}
