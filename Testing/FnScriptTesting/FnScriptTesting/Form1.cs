//#define COMPILERTESTING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FunctionScript;

namespace FnScriptTesting
{
    public partial class Form1 : Form
    {
        int ITERATIONS = 43000000;

        FnScriptCompiler ExpressionCompiler;
        FnScriptExpression<Double> Expression;

        FnVariable<Double> ReturnTemplate;
        //TemplateLocal_Return<Double> ReturnTemplate;

        public Form1()
        {
            InitializeComponent();

            ExpressionCompiler = new FnScriptCompiler();

            //Expression = new FnScriptExpression<Double>(null, null, new List<FnObject> { new FnObject<Form1>(this, false) });
            //Expression.AddLocalParameter<Int32?>("spoof", 5);

            FnScriptResources.AddConstant<Object>("steve", 2.0);

            //FnScriptResources.AddSwitch("CloseWindow", new List<FnScriptResources.CompileFlags> { FnScriptResources.CompileFlags.DO_NOT_CACHE });
            //FnScriptResources.AddMethodPointerToSwitch<Object>("CloseWindow", CloseWindow, new List<Type>());

            ReturnTemplate = new FnVariable<double>(272.0);
        }

        //Testing ghost parameters:
        private Object CloseWindow(FnObject[] arguments)
        {
            (arguments[0] as FnVariable<Form1>).Value.Close();
            return null;
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
#if COMPILERTESTING
            TimeSpan totalTime = System.DateTime.Now.TimeOfDay;

            for (int i = 0; i < ITERATIONS/100; i++)
            {
#endif
                Expression = ExpressionCompiler.Compile<Double>(txtCompileInput.Text, null, null);
#if COMPILERTESTING
            }

            txtCompileOutput.Text = Expression.RawExpression;

            totalTime = System.DateTime.Now.TimeOfDay - totalTime;

            String ticks = "For fnScript 2.5 Compiler, " + (ITERATIONS/100).ToString() + " compilations timing: " + totalTime.ToString();

            this.Text = ticks;
#else
            this.Text = "Expression \"" + txtCompileInput.Text + "\" Compiled Successfully";
#endif
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            TimeSpan totalTime = System.DateTime.Now.TimeOfDay;

            Double result = 0;

            FnObject<Double> returnNode = Expression.ExecutionNode as FnObject<Double>;

            for (int i = 0; i < ITERATIONS; i++)
            {
                result = Expression.Execute();
                //result = returnNode.GetValue();
            }

            txtExecutionResult.Text = result.ToString();

            totalTime = System.DateTime.Now.TimeOfDay - totalTime;

            String ticks = "For fnScript 2.5, " + ITERATIONS.ToString() + " operations timing: " + totalTime.ToString();

            this.Text = ticks;
        }

        private void BtnRawExecute_Click(object sender, EventArgs e)
        {
            TimeSpan totalTime = System.DateTime.Now.TimeOfDay;

            Double result = 0;

            for (int i = 0; i < ITERATIONS; i++)
            {
                result = Math.Round(Math.PI * (Math.Abs(Math.Pow(-3.0, 2.0)) + Math.Sqrt(6027)));
                //result = 272;
                //result = 7.0;
            }

            TxtRawResult.Text = result.ToString();

            totalTime = System.DateTime.Now.TimeOfDay - totalTime;

            String ticks = "For Native Code, " + ITERATIONS.ToString() + " operations timing: " + totalTime.ToString();

            this.Text = ticks;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReturnTemplate.Value = 272.0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan totalTime = System.DateTime.Now.TimeOfDay;

            Double result = 0;

            for (double i = 0; i < ITERATIONS; i++)
            {
                //result = ReturnTemplate.Get();
                
                //THIS IS AS FAST AS SOURCE CODE, HOW TO DO?
                //result = ReturnTemplate._value;

                result = ReturnTemplate.Value;
            }

            txtTemplateResult.Text = result.ToString();

            totalTime = System.DateTime.Now.TimeOfDay - totalTime;

            String ticks = "For Static Template, " + ITERATIONS.ToString() + " operations timing: " + totalTime.ToString();

            this.Text = ticks;

            GenericTest testtest = new Test.NestedTest();
        }
    }

    public interface GenericTest
    {
    }

    public class Test
    {
        public class NestedTest : GenericTest
        {
            Test test;

            void LolCats()
            {
            }
        }
    }
}
