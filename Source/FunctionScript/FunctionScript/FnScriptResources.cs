using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionScript
{
    /// <summary>
    /// This class contains the list of resources that fnScriptExpressions can access, this makes it simple to access pointers to methods for use in fnScript
    /// </summary>
    public static class FnScriptResources
    {
        /// <summary>
        /// Stores all the constants that can be used within FnScript, along with their name
        /// </summary>
        static Dictionary<String, FnObject> Constants;
        /// <summary>
        /// Stores all the method calls that can be used within FnScript, along with their name
        /// </summary>
        internal static Dictionary<String, FnMethodSwitch> FnMethods;
        
        /// <summary>
        /// Stores all method calls that can be used to conduct implicit conversions
        /// </summary>
        internal static Dictionary<Type, FnMethodSwitch> ImplicitConversionSwitches;

        /// <summary>
        /// Stores the precedence of data types that can be provided as arguments to methods
        /// </summary>
        internal static Dictionary<Type, Byte> TypePrecedence;

        /// <summary>
        /// Global parameters that can be accessed by any FnObject
        /// </summary>
        public static Dictionary<String, FnObject> GlobalParameters;

        #region Exception Messages
        const String InvalidNumberOfArguments = "No overload for this function matches the arguments provided.";
        #endregion

        /// <summary>
        /// A random number generator of no seed to use in FnScript methods.
        /// </summary>
        public static Random GenericRandom;

        /// <summary>
        /// Compile flags which can be used in FnScript methods, constants, parameters and FnObjects to alter the way an expression is compiled
        /// </summary>
        public enum CompileFlags
        {
            DO_NOT_CACHE = 0,
            IMPLICIT_CONVERSION,
        }

        /// <summary>
        /// The constructor
        /// </summary>
        static FnScriptResources()
        {
            GlobalParameters = new Dictionary<String, FnObject>();
            ImplicitConversionSwitches = new Dictionary<Type, FnMethodSwitch>();

            TypePrecedence = new Dictionary<Type, Byte>()
            {
                { typeof(SByte), 0 },
                { typeof(Byte), 1 },
                { typeof(Int16), 2 },
                { typeof(UInt16), 3 },
                { typeof(Int32), 4 },
                { typeof(UInt32), 5 },
                { typeof(Int64), 6 },
                { typeof(UInt64), 7 },
                { typeof(Single), 8 },
                { typeof(Double), 10 },
                { typeof(Decimal), 12 },
                //EVERY OTHER DATA TYPE HAS PRECEDENCE 13
                { typeof(Object), 14 }

                //What about nullable data types? Fix this
                // TODO: Fix type precedence for Nullable Types (is this a language feature? Implicit casting of Nullable types?)
            };

            GenericRandom = new Random();

            InitializeConstants();
            InitializeMethods();

            InitializeGlobalParameters();
        }

        /// <summary>
        /// Initializes the constants dictionary and adds in all the default constants that can be used from the FnScript API
        /// </summary>
        static void InitializeConstants()
        {
            Constants = new Dictionary<String, FnObject>();

            #region Mathematical Constants
            AddConstant<Single>("Pi", (Single)Math.PI);
            AddConstant<Double>("Pi_Double", Math.PI);
            AddConstant<Single>("E", (Single)Math.E);
            AddConstant<Double>("E_Double", Math.E);
            AddConstant<Double>("Phi", 1.6180339887);
            AddConstant<Int32>("C", 299792458);
            AddConstant<Boolean>("true", true);
            AddConstant<Boolean>("false", false);

            AddConstant<String>("EmptyString", String.Empty);
            AddConstant<Object>("null", null);
            #endregion
        }

        /// <summary>
        /// Initializes the methods dictionary and adds in all the defualt methods that can be called from the FnScript API
        /// </summary>
        static void InitializeMethods()
        {
            FnMethods = new Dictionary<String, FnMethodSwitch>();

            #region Default FnScript API Methods

            #region Addition Methods
            AddSwitch("Add");
            AddMethodPointerToSwitch<Int32>("Add", new FnMethod_Add_Int32());
            AddMethodPointerToSwitch<UInt32>("Add", new FnMethod_Add_UInt32());
            AddMethodPointerToSwitch<Int64>("Add", new FnMethod_Add_Int64());
            AddMethodPointerToSwitch<UInt64>("Add", new FnMethod_Add_UInt64());
            AddMethodPointerToSwitch<Single>("Add", new FnMethod_Add_Single());
            AddMethodPointerToSwitch<Double>("Add", new FnMethod_Add_Double());
            AddMethodPointerToSwitch<Decimal>("Add", new FnMethod_Add_Decimal());
            AddMethodPointerToSwitch<String>("Add", new FnMethod_Add_String());
            #endregion
            #region Subtraction Methods
            AddSwitch("Subtract");
            AddMethodPointerToSwitch<Int32>("Subtract", new FnMethod_Subtract_Int32());
            AddMethodPointerToSwitch<UInt32>("Subtract", new FnMethod_Subtract_UInt32());
            AddMethodPointerToSwitch<Int64>("Subtract", new FnMethod_Subtract_Int64());
            AddMethodPointerToSwitch<UInt64>("Subtract", new FnMethod_Subtract_UInt64());
            AddMethodPointerToSwitch<Single>("Subtract", new FnMethod_Subtract_Single());
            AddMethodPointerToSwitch<Double>("Subtract", new FnMethod_Subtract_Double());
            AddMethodPointerToSwitch<Decimal>("Subtract", new FnMethod_Subtract_Decimal());
            #endregion
            #region Multiplication Methods
            AddSwitch("Multiply");
            AddMethodPointerToSwitch<Int32>("Multiply", new FnMethod_Multiply_Int32());
            AddMethodPointerToSwitch<UInt32>("Multiply", new FnMethod_Multiply_UInt32());
            AddMethodPointerToSwitch<Int64>("Multiply", new FnMethod_Multiply_Int64());
            AddMethodPointerToSwitch<UInt64>("Multiply", new FnMethod_Multiply_UInt64());
            AddMethodPointerToSwitch<Single>("Multiply", new FnMethod_Multiply_Single());
            AddMethodPointerToSwitch<Double>("Multiply", new FnMethod_Multiply_Double());
            AddMethodPointerToSwitch<Decimal>("Multiply", new FnMethod_Multiply_Decimal());
            #endregion
            #region Division Methods
            AddSwitch("Divide");
            AddMethodPointerToSwitch<Int32>("Divide", new FnMethod_Divide_Int32());
            AddMethodPointerToSwitch<UInt32>("Divide", new FnMethod_Divide_UInt32());
            AddMethodPointerToSwitch<Int64>("Divide", new FnMethod_Divide_Int64());
            AddMethodPointerToSwitch<UInt64>("Divide", new FnMethod_Divide_UInt64());
            AddMethodPointerToSwitch<Single>("Divide", new FnMethod_Divide_Single());
            AddMethodPointerToSwitch<Double>("Divide", new FnMethod_Divide_Double());
            AddMethodPointerToSwitch<Decimal>("Divide", new FnMethod_Divide_Decimal());
            #endregion
            #region Mod Methods
            AddSwitch("Mod");
            AddMethodPointerToSwitch<Int32>("Mod", new FnMethod_Mod_Int32());
            AddMethodPointerToSwitch<UInt32>("Mod", new FnMethod_Mod_UInt32());
            AddMethodPointerToSwitch<Int64>("Mod", new FnMethod_Mod_Int64());
            AddMethodPointerToSwitch<UInt64>("Mod", new FnMethod_Mod_UInt64());
            AddMethodPointerToSwitch<Single>("Mod", new FnMethod_Mod_Single());
            AddMethodPointerToSwitch<Double>("Mod", new FnMethod_Mod_Double());
            AddMethodPointerToSwitch<Decimal>("Mod", new FnMethod_Mod_Decimal());
            #endregion

            #region Unary Operator Methods
            #region Positive Methods
            AddSwitch("Positive");
            AddMethodPointerToSwitch<Byte>("Positive", new FnMethod_Positive_Byte());
            AddMethodPointerToSwitch<SByte>("Positive", new FnMethod_Positive_SByte());
            AddMethodPointerToSwitch<Int16>("Positive", new FnMethod_Positive_Int16());
            AddMethodPointerToSwitch<UInt16>("Positive", new FnMethod_Positive_UInt16());
            AddMethodPointerToSwitch<Int32>("Positive", new FnMethod_Positive_Int32());
            AddMethodPointerToSwitch<UInt32>("Positive", new FnMethod_Positive_UInt32());
            AddMethodPointerToSwitch<Int64>("Positive", new FnMethod_Positive_Int64());
            AddMethodPointerToSwitch<UInt64>("Positive", new FnMethod_Positive_UInt64());
            AddMethodPointerToSwitch<Single>("Positive", new FnMethod_Positive_Single());
            AddMethodPointerToSwitch<Double>("Positive", new FnMethod_Positive_Double());
            AddMethodPointerToSwitch<Decimal>("Positive", new FnMethod_Positive_Decimal());
            #endregion
            #region Negative Methods
            AddSwitch("Negative");
            AddMethodPointerToSwitch<SByte>("Negative", new FnMethod_Negative_SByte());
            AddMethodPointerToSwitch<Int16>("Negative", new FnMethod_Negative_Int16());
            AddMethodPointerToSwitch<Int32>("Negative", new FnMethod_Negative_Int32());
            AddMethodPointerToSwitch<Int64>("Negative", new FnMethod_Negative_Int64());
            AddMethodPointerToSwitch<Single>("Negative", new FnMethod_Negative_Single());
            AddMethodPointerToSwitch<Double>("Negative", new FnMethod_Negative_Double());
            AddMethodPointerToSwitch<Decimal>("Negative", new FnMethod_Negative_Decimal());

            AddMethodPointerToSwitch<Int16>("Negative", new FnMethod_Negative_Byte());
            AddMethodPointerToSwitch<Int32>("Negative", new FnMethod_Negative_UInt16());
            AddMethodPointerToSwitch<Int64>("Negative", new FnMethod_Negative_UInt32());
            #endregion
            #region Not Methods
            AddSwitch("Not");
            AddMethodPointerToSwitch<Boolean>("Not", new FnMethod_Not_Boolean());
            #endregion
            #endregion

            #region Casting Methods
            #region Byte Casting Methods
            AddSwitch("Byte");
            CreateAliasForSwitch("Byte", "byte");
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromByte());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromSByte());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromInt16());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromUInt16());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromInt32());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromUInt32());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromInt64());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromUInt64());

            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromSingle());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromDouble());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromDecimal());

            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromChar());
            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromString());

            AddMethodPointerToSwitch<Byte>("Byte", new FnMethod_Cast_ToByte_FromObject());
            #endregion
            #region SByte Casting Methods
            AddSwitch("SByte");
            CreateAliasForSwitch("SByte", "sbyte");
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromByte());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromSByte());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromInt16());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromUInt16());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromInt32());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromUInt32());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromInt64());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromUInt64());

            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromSingle());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromDouble());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromDecimal());

            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_Cast_ToSByte_FromChar());
            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_CastSByte_FromString());

            AddMethodPointerToSwitch<SByte>("SByte", new FnMethod_CastSByte_FromObject());
            #endregion
            #region Int16 Casting Methods
            AddSwitch("Int16");
            CreateAliasForSwitch("Int16", "short");
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromByte());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromSByte());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromInt16());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromUInt16());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromInt32());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromUInt32());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromInt64());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromUInt64());

            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromSingle());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromDouble());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromDecimal());

            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromChar());
            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromString());

            AddMethodPointerToSwitch<Int16>("Int16", new FnMethod_Cast_ToInt16_FromObject());
            #endregion
            #region UInt16 Casting Methods
            AddSwitch("UInt16");
            CreateAliasForSwitch("UInt16", "ushort");
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromByte());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromSByte());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromInt16());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromUInt16());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromInt32());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromUInt32());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromInt64());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromUInt64());

            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromSingle());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromDouble());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromDecimal());

            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromChar());
            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromString());

            AddMethodPointerToSwitch<UInt16>("UInt16", new FnMethod_Cast_ToUInt16_FromObject());
            #endregion
            #region Int32 Casting Methods
            AddSwitch("Int32");
            CreateAliasForSwitch("Int32", "int");
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromByte());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromSByte());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromInt16());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromUInt16());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromInt32());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromUInt32());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromInt64());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromUInt64());

            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromSingle());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromDouble());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromDecimal());

            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromChar());
            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromString());

            AddMethodPointerToSwitch<Int32>("Int32", new FnMethod_Cast_ToInt32_FromObject());
            #endregion
            #region UInt32 Casting Methods
            AddSwitch("UInt32");
            CreateAliasForSwitch("UInt32", "uint");
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromByte());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromSByte());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromInt16());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromUInt16());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromInt32());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromUInt32());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromInt64());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromUInt64());

            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromSingle());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromDouble());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromDecimal());

            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromChar());
            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromString());

            AddMethodPointerToSwitch<UInt32>("UInt32", new FnMethod_Cast_ToUInt32_FromObject());
            #endregion
            #region Int64 Casting Methods
            AddSwitch("Int64");
            CreateAliasForSwitch("Int64", "long");
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromByte());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromSByte());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromInt16());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromUInt16());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromInt32());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromUInt32());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromInt64());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromUInt64());

            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromSingle());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromDouble());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromDecimal());

            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromChar());
            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromString());

            AddMethodPointerToSwitch<Int64>("Int64", new FnMethod_Cast_ToInt64_FromObject());
            #endregion
            #region UInt64 Casting Methods
            AddSwitch("UInt64");
            CreateAliasForSwitch("UInt64", "ulong");
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromByte());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromSByte());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromInt16());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromUInt16());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromInt32());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromUInt32());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromInt64());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromUInt64());

            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromSingle());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromDouble());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromDecimal());

            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromChar());
            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromString());

            AddMethodPointerToSwitch<UInt64>("UInt64", new FnMethod_Cast_ToUInt64_FromObject());
            #endregion
            #region Single Casting Methods
            AddSwitch("Single");
            CreateAliasForSwitch("Single", "float");
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromByte());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromSByte());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromInt16());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromUInt16());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromInt32());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromUInt32());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromInt64());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromUInt64());

            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromSingle());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromDouble());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromDecimal());

            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromChar());
            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromString());

            AddMethodPointerToSwitch<Single>("Single", new FnMethod_Cast_ToSingle_FromObject());
            #endregion
            #region Double Casting Methods
            AddSwitch("Double");
            CreateAliasForSwitch("Double", "double");
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromByte());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromSByte());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromInt16());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromUInt16());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromInt32());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromUInt32());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromInt64());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromUInt64());

            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromSingle());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromDouble());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromDecimal());

            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromChar());
            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromString());

            AddMethodPointerToSwitch<Double>("Double", new FnMethod_Cast_ToDouble_FromObject());
            #endregion
            #region Decimal Casting Methods
            AddSwitch("Decimal");
            CreateAliasForSwitch("Decimal", "decimal");
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromByte());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromSByte());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromInt16());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromUInt16());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromInt32());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromUInt32());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromInt64());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromUInt64());

            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromSingle());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromDouble());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromDecimal());

            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromChar());
            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromString());

            AddMethodPointerToSwitch<Decimal>("Decimal", new FnMethod_Cast_ToDecimal_FromObject());
            #endregion

            #region Char Casting Methods
            AddSwitch("Char");
            CreateAliasForSwitch("Char", "char");
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromByte());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromSByte());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromInt16());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromUInt16());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromInt32());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromUInt32());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromInt64());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromUInt64());

            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromSingle());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromDouble());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromDecimal());

            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromChar());
            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromString());

            AddMethodPointerToSwitch<Char>("Char", new FnMethod_Cast_ToChar_FromObject());
            #endregion
            #region String Casting Methods
            AddSwitch("String");
            CreateAliasForSwitch("String", "string");
            AddMethodPointerToSwitch<String>("String", new FnMethod_Cast_ToString_FromString());

            AddMethodPointerToSwitch<String>("String", new FnMethod_Cast_ToString_FromObject());
            #endregion
            #region ToString Methods
            AddSwitch("ToString");
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Byte>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<SByte>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Int16>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<UInt16>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Int32>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<UInt32>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Int64>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<UInt64>());

            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Single>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Double>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Decimal>());

            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Char>());
            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<String>());

            AddMethodPointerToSwitch<String>("ToString", new FnMethod_ToString<Object>());
            #endregion

            #region Int32? Casting Methods
            AddSwitch("NullableInt32");
            AddMethodPointerToSwitch<Int32?>("NullableInt32", new FnMethod_ToNullableInt32_FromNull());
            #endregion

            #region Object Casting Methods
            AddSwitch("Object");
            CreateAliasForSwitch("Object", "object");
            AddMethodPointerToSwitch<Object>("Object", new FnMethod_Cast_ToObject_FromObject());
            #endregion
            #endregion
            #region Implicit Conversion Methods

            //#region Int32? Implicit Conversion Methods
// There's an issue with this, but I don't remember what it is... Something about FnScript not being able to determine the correct overload when passing a struct to a method which accepts Nullable<struct>?
            //AddSwitch("ImplicitToNullableInt32", new List<CompileFlags> { CompileFlags.IMPLICIT_CONVERSION });
            //AddMethodPointerToSwitch<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromChar, new List<Type> { typeof(Char) });
            //AddMethodPointerToSwitch<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromByte, new List<Type> { typeof(Byte) });
            //AddMethodPointerToSwitch<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromSByte, new List<Type> { typeof(SByte) });
            //AddMethodPointerToSwitch<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromInt16, new List<Type> { typeof(Int16) });
            //AddMethodPointerToSwitch<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromUInt16, new List<Type> { typeof(UInt16) });
            //AddMethodPointerToSwitch<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromInt32, new List<Type> { typeof(Int32) });
            //AddMethodPointerToSwitch<Int32?>("ImplicitToNullableInt32", ImplicitToNullableInt32_FromNull, new List<Type> { typeof(Object) });
            //#endregion
            #endregion

            #region Comparison Methods
            #region IsGreaterThan Methods
            AddSwitch("IsGreaterThan");
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Byte());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_SByte());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Int16());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_UInt16());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Int32());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_UInt32());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Int64());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_UInt64());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Single());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Double());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Decimal());

            AddMethodPointerToSwitch<Boolean>("IsGreaterThan", new FnMethod_IsGreaterThan_Char());
            #endregion
            #region IsGreaterThanOrEqual Methods
            AddSwitch("IsGreaterThanOrEqual");
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Byte());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_SByte());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Int16());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_UInt16());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Int32());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_UInt32());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Int64());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_UInt64());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Single());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Double());
            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Decimal());

            AddMethodPointerToSwitch<Boolean>("IsGreaterThanOrEqual", new FnMethod_IsGreaterThanOrEqual_Char());
            #endregion
            #region IsLessThan Methods
            AddSwitch("IsLessThan");
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Byte());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_SByte());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Int16());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_UInt16());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Int32());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_UInt32());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Int64());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_UInt64());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Single());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Double());
            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Decimal());

            AddMethodPointerToSwitch<Boolean>("IsLessThan", new FnMethod_IsLessThan_Char());
            #endregion
            #region IsLessThanOrEqual Methods
            AddSwitch("IsLessThanOrEqual");
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Byte());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_SByte());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Int16());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_UInt16());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Int32());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_UInt32());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Int64());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_UInt64());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Single());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Double());
            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Decimal());

            AddMethodPointerToSwitch<Boolean>("IsLessThanOrEqual", new FnMethod_IsLessThanOrEqual_Char());
            #endregion
            #region IsEqual Methods
            AddSwitch("IsEqual");
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Byte());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_SByte());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Int16());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_UInt16());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Int32());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_UInt32());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Int64());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_UInt64());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Single());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Double());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Decimal());

            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Char());
            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_String());

            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Boolean());

            AddMethodPointerToSwitch<Boolean>("IsEqual", new FnMethod_IsEqual_Object());
            #endregion
            #region IsNotEqualMethods
            AddSwitch("IsNotEqual");
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Byte());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_SByte());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Int16());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_UInt16());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Int32());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_UInt32());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Int64());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_UInt64());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Single());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Double());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Decimal());

            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Char());
            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_String());

            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Boolean());

            AddMethodPointerToSwitch<Boolean>("IsNotEqual", new FnMethod_IsNotEqual_Object());
            #endregion
            #region And Methods
            AddSwitch("And");
            AddMethodPointerToSwitch<Boolean>("And", new FnMethod_And());
            #endregion
            #region Nand Methods
            AddSwitch("Nand");
            AddMethodPointerToSwitch<Boolean>("Nand", new FnMethod_Nand());
            #endregion
            #region Or Methods
            AddSwitch("Or");
            AddMethodPointerToSwitch<Boolean>("Or", new FnMethod_Or());
            #endregion
            #region Nor Methods
            AddSwitch("Nor");
            AddMethodPointerToSwitch<Boolean>("Nor", new FnMethod_Nor());
            #endregion
            #region Xor Methods
            AddSwitch("Xor");
            AddMethodPointerToSwitch<Boolean>("Xor", new FnMethod_Xor());
            #endregion
            #endregion

            #region Void Method Wrappers
            AddSwitch("Return");

            //Add multiple void methods as arguments overloads (2 void methods, 3 void methods, etc...)
            AddMethodPointerToSwitch<Byte>("Return", new FnMethod_Return<Byte>());
            AddMethodPointerToSwitch<SByte>("Return", new FnMethod_Return<SByte>());
            AddMethodPointerToSwitch<Int16>("Return", new FnMethod_Return<Int16>());
            AddMethodPointerToSwitch<UInt16>("Return", new FnMethod_Return<UInt16>());
            AddMethodPointerToSwitch<Int32>("Return", new FnMethod_Return<Int32>());
            AddMethodPointerToSwitch<UInt32>("Return", new FnMethod_Return<UInt32>());
            AddMethodPointerToSwitch<Int64>("Return", new FnMethod_Return<Int64>());
            AddMethodPointerToSwitch<UInt64>("Return", new FnMethod_Return<UInt64>());
            AddMethodPointerToSwitch<Single>("Return", new FnMethod_Return<Single>());
            AddMethodPointerToSwitch<Double>("Return", new FnMethod_Return<Double>());
            AddMethodPointerToSwitch<Decimal>("Return", new FnMethod_Return<Decimal>());

            AddMethodPointerToSwitch<Char>("Return", new FnMethod_Return<Char>());
            AddMethodPointerToSwitch<String>("Return", new FnMethod_Return<String>());

            AddMethodPointerToSwitch<Object>("Return", new FnMethod_Return<Object>());
            #endregion

            #region Nullable Types Helper Methods
            AddSwitch("IsNull");
            AddMethodPointerToSwitch<Boolean>("IsNull", new FnMethod_IsNull());

            #region Nullable GetValue Methods
            AddSwitch("GetValue");
            AddMethodPointerToSwitch<Byte>("GetValue", new FnMethod_GetValue<Byte>());
            AddMethodPointerToSwitch<SByte>("GetValue", new FnMethod_GetValue<SByte>());
            AddMethodPointerToSwitch<Int16>("GetValue", new FnMethod_GetValue<Int16>());
            AddMethodPointerToSwitch<UInt16>("GetValue", new FnMethod_GetValue<UInt16>());
            AddMethodPointerToSwitch<Int32>("GetValue", new FnMethod_GetValue<Int32>());
            AddMethodPointerToSwitch<UInt32>("GetValue", new FnMethod_GetValue<UInt32>());
            AddMethodPointerToSwitch<Int64>("GetValue", new FnMethod_GetValue<Int64>());
            AddMethodPointerToSwitch<UInt64>("GetValue", new FnMethod_GetValue<UInt64>());
            AddMethodPointerToSwitch<Single>("GetValue", new FnMethod_GetValue<Single>());
            AddMethodPointerToSwitch<Double>("GetValue", new FnMethod_GetValue<Double>());
            AddMethodPointerToSwitch<Decimal>("GetValue", new FnMethod_GetValue<Decimal>());
            AddMethodPointerToSwitch<Char>("GetValue", new FnMethod_GetValue<Char>());
            //Haven't put Rectangle here because it relies on a library. That will go in the Dynamo FnScript Extension class (yet to be added)
            #endregion
            #endregion

            #region .Net Math Wrapper Methods
            #region Math.Abs
            AddSwitch("Abs");
            AddMethodPointerToSwitch<Decimal>("Abs", new FnMethod_Abs_Decimal());
            AddMethodPointerToSwitch<Double>("Abs", new FnMethod_Abs_Double());
            AddMethodPointerToSwitch<Single>("Abs", new FnMethod_Abs_Single());
            AddMethodPointerToSwitch<Int64>("Abs", new FnMethod_Abs_Int64());
            AddMethodPointerToSwitch<Int32>("Abs", new FnMethod_Abs_Int32());
            AddMethodPointerToSwitch<Int16>("Abs", new FnMethod_Abs_Int16());
            AddMethodPointerToSwitch<SByte>("Abs", new FnMethod_Abs_SByte());
            #endregion
            #region Math.Acos
            AddSwitch("Acos");
            AddMethodPointerToSwitch<Double>("Acos", new FnMethod_Acos_Double());
            AddMethodPointerToSwitch<Single>("Acos", new FnMethod_Acos_Single());
            #endregion
            #region Math.Asin
            AddSwitch("Asin");
            AddMethodPointerToSwitch<Double>("Asin", new FnMethod_Asin_Double());
            AddMethodPointerToSwitch<Single>("Asin", new FnMethod_Asin_Single());
            #endregion
            #region Math.Atan
            AddSwitch("Atan");
            AddMethodPointerToSwitch<Double>("Atan", new FnMethod_Atan_Double());
            AddMethodPointerToSwitch<Single>("Atan", new FnMethod_Atan_Single());
            #endregion
            #region Math.Atan2
            AddSwitch("Atan2");
            AddMethodPointerToSwitch<Single>("Atan2", new FnMethod_Atan2_Single());
            AddMethodPointerToSwitch<Double>("Atan2", new FnMethod_Atan2_Double());
            #endregion
            #region Math.Ceiling
            AddSwitch("Ceiling");
            AddMethodPointerToSwitch<Single>("Ceiling", new FnMethod_Ceiling_Single());
            AddMethodPointerToSwitch<Double>("Ceiling", new FnMethod_Ceiling_Double());
            #endregion
            #region Math.Cos
            AddSwitch("Cos");
            AddMethodPointerToSwitch<Single>("Cos", new FnMethod_Cos_Single());
            AddMethodPointerToSwitch<Double>("Cos", new FnMethod_Cos_Double());
            #endregion
            #region Math.Cosh
            AddSwitch("Cosh");
            AddMethodPointerToSwitch<Single>("Cosh", new FnMethod_Cosh_Single());
            AddMethodPointerToSwitch<Double>("Cosh", new FnMethod_Cosh_Double());
            #endregion
            #region Math.Exp
            AddSwitch("Exp");
            AddMethodPointerToSwitch<Int32>("Exp", new FnMethod_Exp_Int32());
            AddMethodPointerToSwitch<UInt32>("Exp", new FnMethod_Exp_UInt32());
            AddMethodPointerToSwitch<Int64>("Exp", new FnMethod_Exp_Int64());
            AddMethodPointerToSwitch<UInt64>("Exp", new FnMethod_Exp_UInt64());
            AddMethodPointerToSwitch<Single>("Exp", new FnMethod_Exp_Single());
            AddMethodPointerToSwitch<Double>("Exp", new FnMethod_Exp_Double());
            #endregion
            #region Math.Floor
            AddSwitch("Floor");
            AddMethodPointerToSwitch<Single>("Floor", new FnMethod_Floor_Single());
            AddMethodPointerToSwitch<Double>("Floor", new FnMethod_Floor_Double());
            #endregion
            #region Math.IEEERemainder
            AddSwitch("IEEERemainder");
            AddMethodPointerToSwitch<Double>("IEEERemainder", new FnMethod_IEEERemainder());
            #endregion
            #region Math.Log
            AddSwitch("Log");
            AddMethodPointerToSwitch<Single>("Log", new FnMethod_Log_BaseE_Single());
            AddMethodPointerToSwitch<Double>("Log", new FnMethod_Log_BaseE_Double());
            AddMethodPointerToSwitch<Single>("Log", new FnMethod_Log_CustomBase_Single());
            AddMethodPointerToSwitch<Double>("Log", new FnMethod_Log_CustomBase_Double());
            #endregion
            #region Math.Log10
            AddSwitch("Log10");
            AddMethodPointerToSwitch<Single>("Log10", new FnMethod_Log10_Single());
            AddMethodPointerToSwitch<Double>("Log10", new FnMethod_Log10_Double());
            #endregion
            #region Math.Max
            AddSwitch("Max");
            AddMethodPointerToSwitch<Byte>("Max", new FnMethod_Max_Byte());
            AddMethodPointerToSwitch<SByte>("Max", new FnMethod_Max_SByte());
            AddMethodPointerToSwitch<Int16>("Max", new FnMethod_Max_Int16());
            AddMethodPointerToSwitch<UInt16>("Max", new FnMethod_Max_UInt16());
            AddMethodPointerToSwitch<Int32>("Max", new FnMethod_Max_Int32());
            AddMethodPointerToSwitch<UInt32>("Max", new FnMethod_Max_UInt32());
            AddMethodPointerToSwitch<Int64>("Max", new FnMethod_Max_Int64());
            AddMethodPointerToSwitch<UInt64>("Max", new FnMethod_Max_UInt64());
            AddMethodPointerToSwitch<Single>("Max", new FnMethod_Max_Single());
            AddMethodPointerToSwitch<Double>("Max", new FnMethod_Max_Double());
            AddMethodPointerToSwitch<Decimal>("Max", new FnMethod_Max_Decimal());
            #endregion
            #region Math.Min
            AddSwitch("Min");
            AddMethodPointerToSwitch<Byte>("Min", new FnMethod_Min_Byte());
            AddMethodPointerToSwitch<SByte>("Min", new FnMethod_Min_SByte());
            AddMethodPointerToSwitch<Int16>("Min", new FnMethod_Min_Int16());
            AddMethodPointerToSwitch<UInt16>("Min", new FnMethod_Min_UInt16());
            AddMethodPointerToSwitch<Int32>("Min", new FnMethod_Min_Int32());
            AddMethodPointerToSwitch<UInt32>("Min", new FnMethod_Min_UInt32());
            AddMethodPointerToSwitch<Int64>("Min", new FnMethod_Min_Int64());
            AddMethodPointerToSwitch<UInt64>("Min", new FnMethod_Min_UInt64());
            AddMethodPointerToSwitch<Single>("Min", new FnMethod_Min_Single());
            AddMethodPointerToSwitch<Double>("Min", new FnMethod_Min_Double());
            AddMethodPointerToSwitch<Decimal>("Min", new FnMethod_Min_Decimal());
            #endregion
            #region Math.Pow
            AddSwitch("Pow");
            AddMethodPointerToSwitch<Int32>("Pow", new FnMethod_Pow_Int32());
            AddMethodPointerToSwitch<UInt32>("Pow", new FnMethod_Pow_UInt32());
            AddMethodPointerToSwitch<Int64>("Pow", new FnMethod_Pow_Int64());
            AddMethodPointerToSwitch<UInt64>("Pow", new FnMethod_Pow_UInt64());
            AddMethodPointerToSwitch<Double>("Pow", new FnMethod_Pow_Double());
            #endregion
            #region Math.Round
            AddSwitch("Round");
            AddMethodPointerToSwitch<Single>("Round", new FnMethod_Round_Single_1());
            AddMethodPointerToSwitch<Double>("Round", new FnMethod_Round_Double_1());
            AddMethodPointerToSwitch<Decimal>("Round", new FnMethod_Round_Decimal_1());

            AddMethodPointerToSwitch<Single>("Round", new FnMethod_Round_Single_2());
            AddMethodPointerToSwitch<Double>("Round", new FnMethod_Round_Double_2());
            AddMethodPointerToSwitch<Decimal>("Round", new FnMethod_Round_Decimal_2());
            #endregion
            #region Math.Sign
            AddSwitch("Sign");
            AddMethodPointerToSwitch<Int32>("Sign", new FnMethod_Sign_Decimal());
            AddMethodPointerToSwitch<Int32>("Sign", new FnMethod_Sign_Double());
            AddMethodPointerToSwitch<Int32>("Sign", new FnMethod_Sign_Single());
            AddMethodPointerToSwitch<Int32>("Sign", new FnMethod_Sign_Int64());
            AddMethodPointerToSwitch<Int32>("Sign", new FnMethod_Sign_Int32());
            AddMethodPointerToSwitch<Int32>("Sign", new FnMethod_Sign_Int16());
            AddMethodPointerToSwitch<Int32>("Sign", new FnMethod_Sign_SByte());
            #endregion
            #region Math.Sin
            AddSwitch("Sin");
            AddMethodPointerToSwitch<Single>("Sin", new FnMethod_Sin_Single());
            AddMethodPointerToSwitch<Double>("Sin", new FnMethod_Sin_Double());
            #endregion
            #region Math.Sinh
            AddSwitch("Sinh");
            AddMethodPointerToSwitch<Single>("Sinh", new FnMethod_Sinh_Single());
            AddMethodPointerToSwitch<Double>("Sinh", new FnMethod_Sinh_Double());
            #endregion
            #region Math.Sqrt
            AddSwitch("Sqrt");
            AddMethodPointerToSwitch<Single>("Sqrt", new FnMethod_Sqrt_Single());
            AddMethodPointerToSwitch<Double>("Sqrt", new FnMethod_Sqrt_Double());
            #endregion
            #region Math.Tan
            AddSwitch("Tan");
            AddMethodPointerToSwitch<Single>("Tan", new FnMethod_Tan_Single());
            AddMethodPointerToSwitch<Double>("Tan", new FnMethod_Tan_Double());
            #endregion
            #region Math.Tanh
            AddSwitch("Tanh");
            AddMethodPointerToSwitch<Single>("Tanh", new FnMethod_Tanh_Single());
            AddMethodPointerToSwitch<Double>("Tanh", new FnMethod_Tanh_Double());
            #endregion
            #endregion

            #region Bezier Curve Methods
            AddSwitch("BezierCurve");
            AddMethodPointerToSwitch<Single>("BezierCurve", new FnMethod_Bezier_Quadratic_Single());
            AddMethodPointerToSwitch<Double>("BezierCurve", new FnMethod_Bezier_Quadratic_Double());
            AddMethodPointerToSwitch<Single>("BezierCurve", new FnMethod_Bezier_Cubic_Single());
            AddMethodPointerToSwitch<Double>("BezierCurve", new FnMethod_Bezier_Cubic_Double());
            #endregion

            #region Other Maths Methods
            #region Cycle
            AddSwitch("Cycle");
            AddMethodPointerToSwitch<Int32>("Cycle", new FnMethod_Cycle_Int32());
            AddMethodPointerToSwitch<Single>("Cycle", new FnMethod_Cycle_Single());
            #endregion
            #region RandomInt
            AddSwitch("RandomInt");
            AddMethodPointerToSwitch<Int32>("RandomInt", new FnMethod_RandomInt());
            AddMethodPointerToSwitch<Int32>("RandomInt", new FnMethod_RandomInt_Max());
            AddMethodPointerToSwitch<Int32>("RandomInt", new FnMethod_RandomInt_Min_Max());
            #endregion
            #endregion

            #region FnObject Parameter Methods
            AddSwitch("SetParameter");
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Byte>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<SByte>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Int16>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<UInt16>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Int32>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<UInt32>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Int64>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<UInt64>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Single>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Double>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Decimal>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Char>());
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<String>());

            //This method won't provide universal Parameter setting available for all data types,
            //but it's required to get setting parameters of data type "object" to work
            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Object>());

            AddMethodPointerToSwitch<Object>("SetParameter", new FnMethod_SetParameter<Int32?>());
            #endregion

            #region String Methods
            #region String Class Wrapper Methods
            #region SubString
            AddSwitch("SubString");
            AddMethodPointerToSwitch<String>("SubString", new FnMethod_SubString_StartOnly());
            AddMethodPointerToSwitch<String>("SubString", new FnMethod_SubString_StartAndEnd());
            #endregion
            #endregion
            #region Custom String Methods
            #region RandomString
            AddSwitch("RandomString");
            AddMethodPointerToSwitch<String>("RandomString", new FnMethod_RandomString_WithoutPrefix());
            AddMethodPointerToSwitch<String>("RandomString", new FnMethod_RandomString_WithPrefix());
            #endregion
            #region LengthOf
            AddSwitch("LengthOf");
            AddMethodPointerToSwitch<Int32>("LengthOf", new FnMethod_LengthOf());
            #endregion
            #region CharAt
            AddSwitch("CharAt");
            AddMethodPointerToSwitch<Char>("CharAt", new FnMethod_CharAt());
            #endregion
            #region Reverse
            AddSwitch("Reverse");
            AddMethodPointerToSwitch<String>("Reverse", new FnMethod_Reverse());
            #endregion
            #endregion
            #endregion

            #endregion
        }

        static void InitializeGlobalParameters()
        {
        }

        #region Global Parameter Modification Methods
        /// <summary>
        /// Adds a global parameter to the global parameters dictionary, initialized with the specified value
        /// </summary>
        /// <typeparam name="TInput">The data type of the global parameter</typeparam>
        /// <param name="parameterName">The name to assign to the global parameter</param>
        /// <param name="parameterValue">The value to initialize the new parameter with</param>
        public static void AddGlobalParameter<TInput>(String parameterName, TInput parameterValue)
        {
            if (!GlobalParameters.ContainsKey(parameterName))
            {
                GlobalParameters.Add(parameterName, new FnVariable<TInput>(parameterValue));
            }
            else
            {
                throw new ArgumentException("Parameter of name \"" + parameterName + "\" already exists");
            }
        }
        /// <summary>
        /// Sets the value of a specified global parameter with a specified value
        /// </summary>
        /// <typeparam name="TInput">The data type of the global parameter</typeparam>
        /// <param name="parameterName">The name of the global parameter</param>
        /// <param name="parameterValue">The value to assign to the global parameter</param>
        public static void SetGlobalParameter<TInput>(String parameterName, TInput parameterValue)
        {
            if (GlobalParameters.ContainsKey(parameterName))
            {
                if (GlobalParameters[parameterName] is FnVariable<TInput>)
                {
                    (GlobalParameters[parameterName] as FnVariable<TInput>).Value = parameterValue;
                }
                else
                {
                    throw new ArgumentException("Parameter/input type mismatch, expected type " + GlobalParameters[parameterName].GetWrappedObjectType().ToString() + ", recieved value of type " + typeof(TInput).ToString());
                }
            }
            else
            {
                throw new ArgumentException("No parameter of this name exists");
            }
        }
        /// <summary>
        /// Removes the specified global parameter from the global parameter list
        /// </summary>
        /// <param name="parameterName">The name of the parameter to remove from the global parameters list</param>
        public static void RemoveGlobalParameter(String parameterName)
        {
            if (GlobalParameters.ContainsKey(parameterName))
            {
                GlobalParameters.Remove(parameterName);
            }
            else
            {
                throw new ArgumentException("Parameter of name \"" + parameterName + "\" doesn't exists");
            }
        }
        #endregion

        /// <summary>
        /// Adds a constant to the FnScript list of constants with the specified name and value
        /// </summary>
        /// <typeparam name="T">The data type of the constant</typeparam>
        /// <param name="name">The name of the constant</param>
        /// <param name="data">The value to initialize it with</param>
        public static void AddConstant<T>(String name, T data)
        {
            //check the validity of the constant name, constants can only be made of letters, digits or underscores, and must start with a letter or an underscore
            if (IsValidName(name))
            {
                Constants.Add(name, new FnConstant<T>(data));
            }
            else
            {
                throw new ArgumentException("Invalid constant name provided. Names for constants can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank");
            }
        }

        /// <summary>
        /// Creates a new FnMethodSwitch with the specified name and adds it to the list of callable methods from FnScript
        /// </summary>
        /// <param name="name">The name of the switch</param>
        /// <param name="compileFlags">A list of compile flags to add to the switch, which are propagated to any FnObject that is built using the switch</param>
        public static void AddSwitch(String name)
        {
            if (IsValidName(name) && !FnMethods.ContainsKey(name))
            {
                FnMethods.Add(name, new FnMethodSwitch(name));
            }
            else
            {
                throw new ArgumentException("Invalid method name provided. Names for switches can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank");
            }
        }

        /// <summary>
        /// Creates an alias which references a switch. Changes made to the switch at any time are reflected in the alias
        /// </summary>
        /// <param name="switchName">The name of the method switch to alias</param>
        /// <param name="Alias">The alias to use</param>
        public static void CreateAliasForSwitch(String switchName, String alias)
        {
            if (IsValidName(alias) && !FnMethods.ContainsKey(alias))
            {
                FnMethods.Add(alias, FnMethods[switchName]);
            }
            else
            {
                throw new ArgumentException("Invalid alias name provided. Aliases for switches can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank", switchName);
            }
        }

        /// <summary>
        /// Adds a method pointer to the switch of the provided name
        /// </summary>
        /// <typeparam name="T">The return type of the method pointer</typeparam>
        /// <param name="name">The name of the switch to add it to</param>
        /// <param name="pointer">The pointer to the method itself</param>
        public static void AddMethodPointerToSwitch<T>(String name, FnMethod<T> pointer)
        {
            if (FnMethods.ContainsKey(name))
            {
                FnMethods[name].AddMethodPointer(new FnMethodPointer<T>(pointer));
                //We do check for an overload conflict, but instead of doing it here it's done in the FnMethodSwitch.AddMethodPointer() method.
            }
            else
            {
                throw new ArgumentException("Invalid method name provided. A method switch by this name does not exist");
            }
            
            //If this method has an implicit conversion flag
            if (pointer.CompileFlags != null && pointer.CompileFlags.Contains(CompileFlags.IMPLICIT_CONVERSION))
            {
                if (pointer.ArgumentTypes == null || pointer.ArgumentTypes.Length > 1 || pointer.ArgumentTypes.Length == 0)
                {
                    throw new ArgumentException("The FnMethod provided has the incorrect number of parameters. To be a valid Implicit Converion method it must have exactly one parameter.");
                }

                //We have now established that the implicit conversion method provided accepts exactly one method argument. Now we have to determine
                //if it can be added to the list of implicit conversion switches

                //If we don't have an implicit conversion switch for this data type yet, create it.
                if (!ImplicitConversionSwitches.ContainsKey(typeof(T)))
                {
                    ImplicitConversionSwitches.Add(typeof(T), new FnMethodSwitch("ImplicitTo_" + typeof(T).ToString()));
                }

                //Now we check to see if this implicit conversion has been handled already, by looping through the methods in that
                //switch and checking their input parameter type
                foreach (FnMethodPointer m in ImplicitConversionSwitches[typeof(T)].MethodPointers)
                {
                    if (m.GetMethodTypeArray()[0] == pointer.ArgumentTypes[0])
                    {
                        throw new ArgumentException("The implicit conversion specified is already handled by another FnMethod", pointer.ToString());
                    }
                }

                //If we are successful, add the FnMethod to the implicit conversion switch
                ImplicitConversionSwitches[typeof(T)].AddMethodPointer(new FnMethodPointer<T>(pointer));
            }
        }

        /// <summary>
        /// Returns the ambiguity score of a provided argument type versus the desired argument type. The higher the ambiguity score, the more ambiguous the method call is. If a score of -1 is returned, then you cannot implicitly
        /// convert between the two types
        /// </summary>
        /// <param name="methodType">The parameter type for the method</param>
        /// <param name="argumentType">The data type of the provided argument</param>
        /// <returns></returns>
        public static Int32 GetAmbiguityScore(Type methodType, Type argumentType)
        {
            //if the method type can be ambiguous
            if (TypePrecedence.ContainsKey(methodType))
            {
                if (TypePrecedence.ContainsKey(argumentType))
                {
                    if (TypePrecedence[methodType] % 2 == 0)    //if we have a signed method data type
                    {
                        if ((TypePrecedence[argumentType] % 2 == 1) && (TypePrecedence[argumentType] > TypePrecedence[methodType]))     //if we have an unsigned argument data type this is higher precedence than the method type
                        {
                            return -1;
                        }
                    }

                    return TypePrecedence[methodType] - TypePrecedence[argumentType];
                }
                else
                {
                    if (argumentType == typeof(Char))  //if it's a char then we have to do some weird stuff
                    {
                        return TypePrecedence[methodType] - TypePrecedence[typeof(UInt16)];
                    }
                    else //if it's anything else, give it ambiguity level 13 and return the result
                    {
                        return TypePrecedence[methodType] - 13;      //13'S A MAGIC NUMBER BUT IT'S THERE BECAUSE THAT'S THE GAP THAT WAS LEFT BETWEEN DECIMAL AND OBJECT FOR AMBIGUITY SCORES
                    }
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Determines if the string specified is a valid name for a Method or Constant to be used in FnScript
        /// </summary>
        /// <param name="name">The name to verify</param>
        /// <returns></returns>
        public static Boolean IsValidName(String name)
        {
            if (name == "")
            {
                return false;
            }
            else
            {
                if (!(name[0] == '_' || (name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z')))
                {
                    return false;
                }

                for (int i = 1; i < name.Length; i++)
                {
                    if (!(name[i] == '_' || (name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || (name[i] >= '0' && name[i] <= '9')))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Determines if a constant with the specified name exists
        /// </summary>
        /// <param name="name">The name to verify</param>
        /// <returns></returns>
        public static Boolean DoesConstantExist(String name)
        {
            return Constants.ContainsKey(name);
        }
        /// <summary>
        /// Determines if an FnMethodSwitch with the spedified name exists
        /// </summary>
        /// <param name="name">The name to verify</param>
        /// <returns></returns>
        public static Boolean DoesMethodExist(String name)
        {
            return FnMethods.ContainsKey(name);
        }
        /// <summary>
        /// Returns the FnMethodSwitch with the specified name
        /// </summary>
        /// <param name="name">The name of the method</param>
        /// <returns></returns>
        internal static FnMethodSwitch GetMethod(String name)
        {
            if (DoesMethodExist(name)) { return FnMethods[name]; }
            throw new ArgumentException("The method you have requested (" + name + ") does not exist");
        }
        /// <summary>
        /// Returns the FnObject containing the constant with the specified name
        /// </summary>
        /// <param name="name">The name of the constant</param>
        /// <returns></returns>
        public static FnObject GetConstant(String name)
        {
            if (DoesConstantExist(name)) { return Constants[name]; }
            throw new ArgumentException("The constant you have requested (" + name + ") does not exist");
        }

        /// <summary>
        /// Determines if the FnObject provided contains integral data
        /// </summary>
        /// <param name="operand">The FnObject to check</param>
        /// <returns></returns>
        public static Boolean IsIntegerType(FnObject operand)
        {
            if (operand is FnObject<SByte> || operand is FnObject<Byte> || operand is FnObject<Char> || operand is FnObject<Int16> || operand is FnObject<UInt16>
                || operand is FnObject<Int32> || operand is FnObject<UInt32> || operand is FnObject<Int64> || operand is FnObject<UInt64>)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Determines if the Type provided is an integral type
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns></returns>
        public static Boolean IsIntegerType(Type type)
        {
            if (type == typeof(SByte) || type == typeof(Byte) || type == typeof(Char) || type == typeof(Int16) || type == typeof(UInt16) || type == typeof(Int32) || type == typeof(UInt32) || type == typeof(Int64) || type == typeof(UInt64))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the FnObject provided contains floating point data (Single or Double)
        /// </summary>
        /// <param name="operand">The FnObject to check</param>
        /// <returns></returns>
        public static Boolean IsFloatType(FnObject operand)
        {
            return (operand is FnObject<Single> || operand is FnObject<Double>);
        }
        /// <summary>
        /// Determines if the Type provided is a floating point data type (Single or Double)
        /// </summary>
        /// <param name="type">The Type to check</param>
        /// <returns></returns>
        public static Boolean IsFloatType(Type type)
        {
            return (type == typeof(Single) || type == typeof(Double));
        }

        /// <summary>
        /// Determines if the FnObject provided is a valid numerical data type
        /// </summary>
        /// <param name="operand">The FnObject to check</param>
        /// <returns></returns>
        public static Boolean IsNumberType(FnObject operand)
        {
            return (IsIntegerType(operand) || IsFloatType(operand));
        }
        /// <summary>
        /// Determines if the Type provided is a valid numerical data type
        /// </summary>
        /// <param name="type">The Type to check</param>
        /// <returns></returns>
        public static Boolean IsNumberType(Type type)
        {
            return (IsIntegerType(type) || IsFloatType(type));
        }

    }
}
