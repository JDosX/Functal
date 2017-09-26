using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionScript
{
    public class FnScriptCompiler
    {
        //POLICY: THE COMPILER SHOULD NOT STORE ANY VALUES RELATING TO THE EXPRESSION AFTER IT HAS BEEN COMPILED.
        //THAT SHOULD ALL BE STORED LOCALLY IN THE COMPILE METHOD, PASSED TO THE CREATED EXPRESSION AND THEN DELETED.

        #region Data

        /// <summary>
        /// The possible profiles each of the characters in an expression string can have. Some of these are only used during syntax checking.
        /// </summary>
        enum FnObjectProfiles
        {
            Constant = 0,
            ParameterBody,
            StringBody,
            CharBody,
            Number,
            NumericSuffix,
            SByte,
            Byte,
            Int16,
            UInt16,
            Int32,
            UInt32,
            Int64,
            UInt64,
            Single,
            Double,
            Operator,
            BinaryOperator,
            UnaryPrefixOperator,
            UnarySuffixOperator,
            Name,
            MethodName,
            StartGrouping,
            EndGrouping,
            DivisionGrouping,
            Unassessed,
        }

        #region Binary Operators
        /// <summary>
        /// Stores the list of Binary Operators allowable in FnScript
        /// </summary>
        private List<String> BinaryOperators = new List<String>
        {
            {"&&"},
            {"!&&"},
            {"||"},
            {"!||"},
            {"^"},
            {">"},
            {"<"},
            {"=="},
            {"<="},
            {">="},
            {"!="},
            {"+"},
            {"-"},
            {"*"},
            {"/"},
            {"%"}
        };
        #endregion

        #region BinaryOperatorPrecedence
        /// <summary>
        /// Stores the precedences of each Binary Operator
        /// </summary>
        private Dictionary<String, Int32> BinaryOperatorPrecedence = new Dictionary<string, int>
        {
            {"&&", 0},
            {"!&&", 0},
            {"||", 0},
            {"!||", 0},
            {"^", 0},
            {">", 1},
            {"<", 1},
            {"==", 1},
            {"<=", 1},
            {">=", 1},
            {"!=", 1},
            {"+", 2},
            {"-", 2},
            {"*", 3},
            {"/", 3},
            {"%", 3}
        };
        #endregion

        #region Unary Prefix Operators
        /// <summary>
        /// Stores the list of Unary Prefix Operators
        /// </summary>
        private List<String> UnaryPrefixOperators = new List<String>
            {
                {"+"},
                {"-"},
                {"!"}
            };
        #endregion

        #region Unary Prefix Operator Precedence
        /// <summary>
        /// Stores the precedences of each Unary Prefix Operator
        /// </summary>
        private Dictionary<String, Int32> UnaryPrefixOperatorPrecedence = new Dictionary<String, Int32>
            {
                {"+", 4},
                {"-", 4},
                {"!", 4}
            };
        #endregion

        #region Unary Suffix Operators
        /// <summary>
        /// Stores the list of Unary Suffix Operators allowable in FnScript
        /// </summary>
        private List<String> UnarySuffixOperators = new List<String>(0);
        #endregion

        #region Unary Suffix Operator Precedence
        /// <summary>
        /// Stores the precedences of each Unary Suffix Operator
        /// </summary>
        private Dictionary<String, Int32> UnarySuffixOperatorPrecedence = new Dictionary<String, Int32>(0);
        #endregion

        /// <summary>
        /// Stores all the possible characters that could make up FnScript operators and grouping symbols
        /// </summary>
        private char[] OperatorsAndGrouping = { '%', '(', ')', '*', '+', ',', '-', '/', '<', '=', '>', '&', '|', '!', '^' };
        /// <summary>
        /// Stores all the possible characters that could make up FnScript operators 
        /// </summary>
        private char[] Operators = { '%', '*', '+', '-', '/', '<', '=', '>', '&', '|', '!', '^' };
        /// <summary>
        /// Stores all the start grouping symbols for FnScript expressions
        /// </summary>
        private char[] StartGrouping = { '(' };
        /// <summary>
        /// Stores all the end grouping symbols for FnScript expressions
        /// </summary>
        private char[] EndGrouping = { ')' };
        /// <summary>
        /// Stores all the division grouping symbols for FnScript expressions
        /// </summary>
        private char[] DivisionGrouping = { ',' };
        /// <summary>
        /// Stores all the possible grouping symbols for FnScript expressions
        /// </summary>
        private char[] Grouping = { '(', ')', ',' };

        #region Parameter Start and End Character Variables
        /// <summary>
        /// Represents the start of a parameter
        /// </summary>
        private const char StartParam = '[';
        /// <summary>
        /// Represents the end of a parameter
        /// </summary>
        private const char EndParam = ']';
        #endregion

        #endregion

        public FnScriptCompiler()
        {
            Array.Sort<Char>(OperatorsAndGrouping);
            Array.Sort<Char>(Operators);

            //may be needed
            Array.Sort<Char>(Grouping);
        }

        /// <summary>
        /// Compiles an expression in string form into an execution tree by checking the syntax and then constructing an execution tree. The lead node is then evaluated when calling execute on the expression
        /// </summary>
        /// <param name="expression">The FnScript expression to compile</param>
        public FnScriptExpression<T> Compile<T>(string expression, Dictionary<String, FnObject> localParameters, Dictionary<String, FnObject> collectionParameters)
        {
            #region Data Needed to construct the final FnScriptExpression 

            string rawExpression = "";
            List<FnObject> executionList = new List<FnObject>();

            FnVariable<Boolean> isPreExecute = new FnVariable<Boolean>(false);

            // Stores a list of booleans to determine if an FnObject has been bound as a parameter for another yet
            List<Boolean> isBound = new List<Boolean>();

            //Stores an aggregated dictionary of parameters that properly respects Parameter Precedence levels
            Dictionary<String, FnObject> parameters;

            #endregion

            #region Setup Parameters

            //COME BACK TO THIS, CONSIDER ADDING PRIVATE VARIABLE LIST (PRIVATE TO EXPRESSION ONLY)
            //AddLocalGhostArgument_ParentExpression<T>(ref ghostArguments, ref returnExpression);

            //Here is where we're going to aggregate the parameter dictionaries into one
            parameters = AggregateParameters(localParameters, collectionParameters);

            #endregion

            rawExpression = expression;

            expression = expression.Trim();

            #region Initialize character profile list
            List<FnObjectProfiles> characterProfiles = new List<FnObjectProfiles>(expression.Length);
            for (int i = 0; i < expression.Length; i++)
            {
                characterProfiles.Add(FnObjectProfiles.Unassessed);
            }
            #endregion

            Stack<Int32> methodBracketBalances = new Stack<Int32>();
            Int32 bracketBalance = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                //now loop through the expression and classify each character it comes across. Along the way, remove literal defining characters,
                //convert escape character declarations into actual escape characters, remove numeric literal suffixes, and designate each number
                //with the correct type based on the defining suffix that was just removed

                if (FollowsNumericStartRule(expression[i]))                                 //Check and Format Numbers
                {
                    FormatNumber(ref expression, ref characterProfiles, ref i);
                }
                else if (FollowsOperatorStartRule(expression[i]))                           //Check and format operators
                {
                    FormatOperator(ref expression, ref characterProfiles, ref i);
                }
                else if (FollowsNameStartRule(expression[i]))                               //Check and Format Constants and Method Calls
                {
                    FormatMethodOrConstant(ref expression, ref characterProfiles, ref i, bracketBalance, methodBracketBalances);
                }
                else if (FollowsStartGroupingRule(expression[i]))                           //Check and Format Start Grouping
                {
                    FormatStartGrouping(ref expression, ref characterProfiles, ref i, ref bracketBalance);
                }
                else if (FollowsEndGroupingRule(expression[i]))                             //Check and format end grouping
                {
                    FormatEndGrouping(ref expression, ref characterProfiles, ref i, ref bracketBalance, ref methodBracketBalances);
                }
                else if (FollowsDivisionGroupingRule(expression[i]))                        //Check for and and format division grouping
                {
                    FormatDivisionGrouping(ref expression, ref characterProfiles, ref i, ref bracketBalance, ref methodBracketBalances);
                }
                else if (FollowsParameterStartRule(expression[i]))                          //Check and format parameters
                {
                    FormatParameter(ref expression, ref characterProfiles, ref parameters, ref i);
                }
                else if (FollowsStringStartRule(expression[i]))                             //Check and format strings
                {
                    FormatString(ref expression, ref characterProfiles, ref i);
                }
                else if (FollowsCharStartRule(expression[i]))                               //Check and format characters
                {
                    FormatChar(ref expression, ref characterProfiles, ref i);
                }
                else                                                                        //you tried to do something that isn't cool, throw dat exception
                {
                    throw new ArgumentException("Syntax error, consult expression");
                }
            }

            //check there is no open/close bracket count mismatch
            if (bracketBalance != 0)
            {
                throw new ArgumentException("Open/Close bracket mismatch", expression);
            }

            ConvertToExecutionTree(expression, characterProfiles, ref parameters, ref executionList, ref isBound, isPreExecute);

            //lastly, check our root node matches return type. If not, them attempt to add in an implicit casting method
            if (executionList.Last().GetWrappedObjectType() != (typeof(T)))
            {
                if (FnScriptResources.ImplicitConversionSwitches.ContainsKey(typeof(T)))
                {
                    executionList.Add(FnScriptResources.ImplicitConversionSwitches[typeof(T)].CreateObjectWithPointer(new List<FnObject> { executionList.Last() }, parameters, isPreExecute));
                    isBound[isBound.Count - 1] = true;
                    isBound.Add(false);
                }
                else
                {
                    throw new ArgumentException("The output type of the expression doesn't match the specified return type", expression);
                }
            }

            // TODO: This is a temporary patch up to push the execution node through the optimiser rather than the entire list
            // We need to extend node based copilation instead of list based compilation throughout the entire FnScriptCompiler
            FnObject<T> executionNode = executionList.Last() as FnObject<T>;

            // Optimize the expression tree
            CacheExpression(ref executionNode);

            //TODO: MAKE THIS RETURN THE CORRECT FNSCRIPTEXPRESSION
            FnScriptExpression<T> returnExpression = new FnScriptExpression<T>(executionNode, rawExpression, parameters, isPreExecute);
            
            return returnExpression;
        }

        /// <summary>
        /// Converts the provided minimised expression into an execution tree that can be executed when desired.
        /// </summary>
        /// <param name="expression">The expression to compile in minimised string format</param>
        /// <param name="characterProfiles">The profile for each character in the string, to be used to determine the purpose of each element in the expression</param>
        private void ConvertToExecutionTree(String expression, List<FnObjectProfiles> characterProfiles, ref Dictionary<String, FnObject> parameters, ref List<FnObject> executionList, ref List<Boolean> isBound, FnVariable<Boolean> isPreExecute)
        {
            Stack<String> operatorStack = new Stack<String>();
            Stack<FnObjectProfiles> operatorProfileStack = new Stack<FnObjectProfiles>();

            for (int i = 0; i < expression.Length; i++)
            {
                //scan through the profiled expression and create FnObjects accordingly
                if (IsLiteralTypeProfile(characterProfiles[i]))                             //if we get any of our literal data types
                {
                    AddLiteralToExecutionTree(expression, characterProfiles, ref executionList, ref isBound, ref i);
                }
                else if (IsOperatorTypeProfile(characterProfiles[i]))                       //if we get an operator
                {
                    AddOperatorToExecutionTree(expression, characterProfiles, ref i, ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
                }
                else if (characterProfiles[i] == FnObjectProfiles.StartGrouping)
                {
                    operatorStack.Push(expression[i].ToString());
                    operatorProfileStack.Push(characterProfiles[i]);
                }
                else if (characterProfiles[i] == FnObjectProfiles.EndGrouping)
                {
                    while (operatorStack.Peek() != "(")
                    {
                        PopOperatorToExecutionTree(ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
                    }

                    operatorStack.Pop();
                    operatorProfileStack.Pop();
                }
                else if (characterProfiles[i] == FnObjectProfiles.ParameterBody)
                {
                    AddParameterInstanceToExecutionTree(expression, characterProfiles, ref parameters, ref executionList, ref isBound, ref i);
                }
                else if (characterProfiles[i] == FnObjectProfiles.Constant)
                {
                    AddConstantToExecutionTree(expression, characterProfiles, ref executionList, ref isBound, ref i);
                }
                else if (characterProfiles[i] == FnObjectProfiles.MethodName)
                {
                    AddMethodToExecutionTree(expression, characterProfiles, ref parameters, ref executionList, ref isBound, ref i, isPreExecute);
                }
                else
                {
                    throw new ArgumentException("The Execution tree doesn't support this type of object");
                }
            }

            while (operatorStack.Count != 0)
            {
                PopOperatorToExecutionTree(ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
            }
        }

        /// <summary>
        /// Executes all nodes of the tree that are not marked with a DO_NOT_CACHE flag, deletes child nodes in the execution tree, and then converts that node into a variable
        /// </summary>
        private void CacheExpression<T>(ref FnObject<T> executionNode)
        {
            executionNode = executionNode.CheckAndCache() as FnObject<T>;
        }

        #region Ghost Argument and Parameter Setup Methods

        /// <summary>
        /// Aggregates all Local, Collection and Global parametes into a single parameter Dictionary. Conflicting parameter names will be resolved in order of precedence,
        /// which is Local, Collection, then Global.
        /// </summary>
        /// <param name="localParameters">The Parameter Dictionary to be treated as a set of Local Parameters</param>
        /// <param name="collectionParameters">The Parameter Dictionary to be treated as a set of Collection Parameters</param>
        /// <returns></returns>
        private Dictionary<String, FnObject> AggregateParameters(Dictionary<String, FnObject> localParameters, Dictionary<String, FnObject> collectionParameters)
        {
            //If the local and collection parameter lists if either of them are null
            if (localParameters == null) { localParameters = new Dictionary<String, FnObject>(); }
            if (collectionParameters == null) { collectionParameters = new Dictionary<String, FnObject>(); }

            //Create the output list. It will contain at least the local parameters, so we create the
            //dictionary with the list pre-added.
            Dictionary<String, FnObject> outputDictionary = new Dictionary<String, FnObject>(localParameters);

            //Add the collection parameters, discarding any with a conflicting name to what is already present
            for (int i = 0; i < collectionParameters.Count; i++)
            {
                //Extract the key as we will use it twice
                String collectionKey = collectionParameters.ElementAt(i).Key;

                if (!outputDictionary.ContainsKey(collectionKey))
                {
                    outputDictionary.Add(collectionKey, collectionParameters[collectionKey]);
                }
            }

            //Add the global parameters, discarding any with a conflicting name to what is already present
            for (int i = 0; i < FnScriptResources.GlobalParameters.Count; i++)
            {
                //Extract the key as we will use it twice
                String globalKey = FnScriptResources.GlobalParameters.ElementAt(i).Key;

                if (!outputDictionary.ContainsKey(globalKey))
                {
                    outputDictionary.Add(globalKey, FnScriptResources.GlobalParameters[globalKey]);
                }
            }

            return outputDictionary;
        }

        private void AddLocalGhostArgument_ParentExpression<T>(ref List<FnObject> ghostArguments, ref FnScriptExpression<T> expression)
        {
            //Add local ghost arguments

            //I THINK THIS IS UNSATISFACTORY, WE HAVE TO SPEED THIS UP
            ghostArguments.Insert(0, new FnVariable<FnScriptExpression>(expression));
        }

        #endregion

        #region Validity Methods

        #region Generic Operand Rules

        /// <summary>
        /// Determines if the character provided is a valid characterto start any operand with
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean IsOperandStartCharacter(Char expressionCharacter)
        {
            if (FollowsStringStartRule(expressionCharacter) || FollowsCharStartRule(expressionCharacter) || FollowsNameStartRule(expressionCharacter) || FollowsNumericStartRule(expressionCharacter) || FollowsParameterStartRule(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Number Rules
        /// <summary>
        /// Determines if the character provided follows the rules to start a numeric literal
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsNumericStartRule(Char expressionCharacter)
        {
            if ((expressionCharacter >= '0' && expressionCharacter <= '9') || FollowsNumericDecimalRule(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be a valid part of the body for a numeric data type
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsNumericBodyRule(Char expressionCharacter)
        {
            if (FollowsNumericStartRule(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be a numeric decimal point
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsNumericDecimalRule(Char expressionCharacter)
        {
            if (expressionCharacter == '.')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be the suffix for a numeric literal
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsNumericSuffixRule(Char expressionCharacter)
        {
            if ((expressionCharacter >= 'a' && expressionCharacter <= 'z') || (expressionCharacter >= 'A' && expressionCharacter <= 'Z'))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region String Rules

        /// <summary>
        /// Determines if the provided character follows the rules to be a valid start to a literal string declaration
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsStringStartRule(Char expressionCharacter)
        {
            if (expressionCharacter == '"')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be a valid end to a literal string declaration
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsStringEndRule(Char expressionCharacter)
        {
            if (expressionCharacter == '"')
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Char Rules

        /// <summary>
        /// Determines if the provided character follows the rules to be a valid start to a literal Char declaration
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsCharStartRule(Char expressionCharacter)
        {
            if (expressionCharacter == '\'')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be the end of a literal Char declaration
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsCharEndRule(Char expressionCharacter)
        {
            if (expressionCharacter == '\'')
            {
                return true;
            }
            return false;
        }
        #endregion

        #region ParameterRules

        /// <summary>
        /// Determines if the character provided follows the rules to be the start of a parameter
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsParameterStartRule(Char expressionCharacter)
        {
            if (expressionCharacter == '[')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be a body character for a parameter
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsParameterBodyRule(Char expressionCharacter)
        {
            if (!FollowsParameterStartRule(expressionCharacter) && !FollowsParameterEndRule(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be the end character for a parameter
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsParameterEndRule(Char expressionCharacter)
        {
            if (expressionCharacter == ']')
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Operator rules

        /// <summary>
        /// Determines whether the provided character follows the rules to be the start character for an operator
        /// </summary>
        /// <param name="expressionCharacter">The character to be analysed</param>
        /// <returns></returns>
        private Boolean FollowsOperatorStartRule(Char expressionCharacter)
        {
            if (Operators.Contains(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be the body character of an operator
        /// </summary>
        /// <param name="expressionCharacter">The character to be analysed</param>
        /// <returns></returns>
        private Boolean FollowsOperatorBodyRule(Char expressionCharacter)
        {
            if (FollowsOperatorStartRule(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rule to be a start grouping character
        /// </summary>
        /// <param name="expressionCharacter">The character to be analysed</param>
        /// <returns></returns>
        private Boolean FollowsStartGroupingRule(Char expressionCharacter)
        {
            if (StartGrouping.Contains(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be an end grouping character
        /// </summary>
        /// <param name="expressionCharacter">The character to be analysed</param>
        /// <returns></returns>
        private Boolean FollowsEndGroupingRule(Char expressionCharacter)
        {
            if (EndGrouping.Contains(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the provided character follows the rules to be a division grouping separator
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsDivisionGroupingRule(Char expressionCharacter)
        {
            if (DivisionGrouping.Contains(expressionCharacter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the characters surround an operator quality it to be a Binary Operator
        /// </summary>
        /// <param name="expression">The expression to analyse</param>
        /// <param name="profiles">The profiles for each character in the expression</param>
        /// <param name="startIndex">The index of the start of the operator</param>
        /// <param name="successorIndex">The index of the first character after the operator</param>
        /// <returns></returns>
        private Boolean FollowsBinarySurroundingRules(ref String expression, ref List<FnObjectProfiles> profiles, Int32 startIndex, Int32 successorIndex)
        {
            //check what the prefix to the operator is
            if (startIndex > 0)
            {
                if (!((profiles[startIndex - 1] == FnObjectProfiles.UnarySuffixOperator) || profiles[startIndex - 1] == FnObjectProfiles.EndGrouping || IsOperandEndProfile(profiles[startIndex - 1])))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            //check what the suffix to the operator is
            while (successorIndex < expression.Length && expression[successorIndex] == ' ')
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, successorIndex);
            }

            if (successorIndex >= expression.Length)
            {
                return false;
            }
            else
            {
                if (FollowsOperatorStartRule(expression[successorIndex]) || FollowsStartGroupingRule(expression[successorIndex]) || IsOperandStartCharacter(expression[successorIndex]))
                {
                    return true;
                }
            }

            //if we have passed all the conditions, return true
            return false;
        }

        /// <summary>
        /// Determines if the characters surround an operator quality it to be a Unary Prefix Operator
        /// </summary>
        /// <param name="expression">The expression to analyse</param>
        /// <param name="profiles">The profiles for each character in the expression</param>
        /// <param name="startIndex">The index of the start of the operator</param>
        /// <param name="successorIndex">The index of the first character after the operator</param>
        /// <returns></returns>
        private Boolean FollowsUnaryPrefixSurroundingRules(ref String expression, ref List<FnObjectProfiles> profiles, Int32 startIndex, Int32 successorIndex)
        {
            if (startIndex == 0 || profiles[startIndex - 1] == FnObjectProfiles.StartGrouping || profiles[startIndex - 1] == FnObjectProfiles.DivisionGrouping || profiles[startIndex - 1] == FnObjectProfiles.BinaryOperator)
            {
                //we successfully follow the prefix surrounding rules
            }
            else
            {
                return false;
            }

            //remove unneccessary white spaces from in front of the operator
            while (successorIndex < expression.Length && expression[successorIndex] == ' ')
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, successorIndex);
            }

            if (successorIndex < expression.Length && (FollowsStartGroupingRule(expression[successorIndex]) || IsOperandStartCharacter(expression[successorIndex])))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if the characters surrounding an operator qualify the operator for being a Unary Suffix Operator
        /// </summary>
        /// <param name="expression">The expression to analyse</param>
        /// <param name="profiles">The profiles for each character in the expression</param>
        /// <param name="startIndex">The index of the start of the operator</param>
        /// <param name="successorIndex">The index of the first character after the operator</param>
        /// <returns></returns>
        private Boolean FollowsUnarySuffixSurroundingRules(ref String expression, ref List<FnObjectProfiles> profiles, Int32 startIndex, Int32 successorIndex)
        {
            if (startIndex > 0 && (profiles[startIndex - 1] == FnObjectProfiles.EndGrouping || IsOperandEndProfile(profiles[startIndex - 1])))
            {
                //we have successfully follows the prefix surrounding rules
            }
            else
            {
                return false;
            }

            //remove unneccessary white spaces from in front of the operator
            while (successorIndex < expression.Length && expression[successorIndex] == ' ')
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, successorIndex);
            }

            if (successorIndex == expression.Length || FollowsEndGroupingRule(expression[successorIndex]) || FollowsDivisionGroupingRule(expression[successorIndex]) || FollowsOperatorStartRule(expression[successorIndex]))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the characters which follow the operand are valid, and also formats the string to remove unneccessary white spaces
        /// </summary>
        /// <param name="expression">The expression to analyse</param>
        /// <param name="profiles">The profiles for each character in the string</param>
        /// <param name="index">The index of the first character after the operator</param>
        /// <returns></returns>
        private Boolean FollowsOperandSuccessorRule(ref String expression, ref List<FnObjectProfiles> profiles, Int32 index)
        {
            if (index >= expression.Length)
            {
                return true;
            }
            else if (expression[index] == ' ')
            {
                while (index < expression.Length && expression[index] == ' ')
                {
                    RemoveCharacterFromExpression(ref expression, ref profiles, index);
                }
            }

            if ((index >= expression.Length) || (expression[index] == ' ') || (Operators.Contains(expression[index])) || (expression[index] == ',') || (expression[index] == ')'))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Method and Constant Rules

        /// <summary>
        /// Determines if the character provided is the valid start to a name for a method or constant
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsNameStartRule(Char expressionCharacter)
        {
            if ((expressionCharacter >= 'A' && expressionCharacter <= 'Z') || (expressionCharacter >= 'a' && expressionCharacter <= 'z') || expressionCharacter == '_')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the next character in the expression string is valid for the body of a method or constant name
        /// </summary>
        /// <param name="expressionCharacter">The character to analyse</param>
        /// <returns></returns>
        private Boolean FollowsNameBodyRule(Char expressionCharacter)
        {
            if (FollowsNameStartRule(expressionCharacter) || (expressionCharacter >= '0' && expressionCharacter <= '9'))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the next character in the string is a valid character to follow a method name with
        /// </summary>
        /// <param name="expression">The expression to analyse</param>
        /// <param name="profiles">The profiles for each character in the expression</param>
        /// <param name="index">The index of the character succeeding the method name</param>
        /// <returns></returns>
        private Boolean FollowsMethodNameSuccessorRule(ref String expression, ref List<FnObjectProfiles> profiles, Int32 index)
        {
            while (index < expression.Length && expression[index] == ' ')
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, index);
            }

            if (index < expression.Length && expression[index] == '(')
            {
                return true;
            }
            return false;
        }
        
        #endregion

        #endregion

        #region Profile And DataType Analysis Methods

        /// <summary>
        /// Determines if the profile provided is a valid profile to end an operand
        /// </summary>
        /// <param name="profile">The profile to analyse</param>
        /// <returns></returns>
        private Boolean IsOperandEndProfile(FnObjectProfiles profile)
        {
            if (profile == FnObjectProfiles.StringBody || profile == FnObjectProfiles.CharBody
                || profile == FnObjectProfiles.Constant
                || profile == FnObjectProfiles.ParameterBody
                || profile == FnObjectProfiles.Byte || profile == FnObjectProfiles.SByte
                || profile == FnObjectProfiles.Int16 || profile == FnObjectProfiles.UInt16
                || profile == FnObjectProfiles.Int32 || profile == FnObjectProfiles.UInt32
                || profile == FnObjectProfiles.Int64 || profile == FnObjectProfiles.UInt64
                || profile == FnObjectProfiles.Single || profile == FnObjectProfiles.Double)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the profile provided is a valid profile for a numeric literal data type
        /// </summary>
        /// <param name="profile">The profile to analyse</param>
        /// <returns></returns>
        private Boolean IsNumericTypeProfile(FnObjectProfiles profile)
        {
            if (profile == FnObjectProfiles.Byte || profile == FnObjectProfiles.SByte
                || profile == FnObjectProfiles.Int16 || profile == FnObjectProfiles.UInt16
                || profile == FnObjectProfiles.Int32 || profile == FnObjectProfiles.UInt32
                || profile == FnObjectProfiles.Int64 || profile == FnObjectProfiles.UInt64
                || profile == FnObjectProfiles.Single || profile == FnObjectProfiles.Double)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the profile provided is a valid profile for a literal
        /// </summary>
        /// <param name="profile">The profile to analyse</param>
        /// <returns></returns>
        private Boolean IsLiteralTypeProfile(FnObjectProfiles profile)
        {
            if (profile == FnObjectProfiles.StringBody || profile == FnObjectProfiles.CharBody
                || profile == FnObjectProfiles.Byte || profile == FnObjectProfiles.SByte
                || profile == FnObjectProfiles.Int16 || profile == FnObjectProfiles.UInt16
                || profile == FnObjectProfiles.Int32 || profile == FnObjectProfiles.UInt32
                || profile == FnObjectProfiles.Int64 || profile == FnObjectProfiles.UInt64
                || profile == FnObjectProfiles.Single || profile == FnObjectProfiles.Double)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the FnObjectProfile provided is a valid profile for an operator
        /// </summary>
        /// <param name="profile">The profile to analyse</param>
        /// <returns></returns>
        private Boolean IsOperatorTypeProfile(FnObjectProfiles profile)
        {
            if (profile == FnObjectProfiles.UnaryPrefixOperator || profile == FnObjectProfiles.UnarySuffixOperator || profile == FnObjectProfiles.BinaryOperator)
            {
                return true;
            }
            return false;
        }
        
        #endregion

        #region Formatting Methods

        /// <summary>
        /// Analyses and formats a string literal in the expression into a minimised format, and profiles each character in the string literal in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character in the expression</param>
        /// <param name="index">The index the string literal starts at</param>
        private void FormatString(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index)
        {
            Int32 stringStart = index;
            Int32 stringSuccessor;

            if (!FollowsStringStartRule(expression[index]))
            {
                throw new ArgumentException("the position provided isn't the start of a String", index.ToString());
            }
            else
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, index);
                //profiles[index] = FnObjectProfiles.StringStart;
                //index += 1;

                while (!FollowsStringEndRule(expression[index]))
                {
                    if (expression[index] == '\\')  //if we have an escape character, format it as such and continue
                    {
                        RemoveCharacterFromExpression(ref expression, ref profiles, index);

                        //now look at the escape character and see which escape character it is, if it's one at all
                        if (expression[index] == 'a') { ReplaceAt(ref expression, index, "\a"); }
                        else if (expression[index] == 'b') { ReplaceAt(ref expression, index, "\b"); }
                        else if (expression[index] == 'f') { ReplaceAt(ref expression, index, "\f"); }
                        else if (expression[index] == 'n') { ReplaceAt(ref expression, index, "\n"); }
                        else if (expression[index] == 'r') { ReplaceAt(ref expression, index, "\r"); }
                        else if (expression[index] == 't') { ReplaceAt(ref expression, index, "\t"); }
                        else if (expression[index] == 'v') { ReplaceAt(ref expression, index, "\v"); }
                        else if (expression[index] == '\'') { ReplaceAt(ref expression, index, "\'"); }
                        else if (expression[index] == '"') { ReplaceAt(ref expression, index, "\""); }
                        else if (expression[index] == '\\') { ReplaceAt(ref expression, index, "\\"); }
                        else { throw new ArgumentException("Unrecognised escape sequence", expression[index].ToString()); }
                    }

                    profiles[index] = FnObjectProfiles.StringBody;

                    index += 1;

                    //if we have exceeded our range, then throw exception
                    if (index >= expression.Length) { throw new ArgumentException("String was not closed, did you forget a \"?", expression.ToString()); }
                }

                //profiles[index] = FnObjectProfiles.StringEnd;
                RemoveCharacterFromExpression(ref expression, ref profiles, index);
                stringSuccessor = index;

                //determine if we hit upong an empty string
                if (stringStart == stringSuccessor)
                {
                    //we hit upon an empty string, let's insert the EmptyString constant and go from there
                    //expression = expression.Insert(stringStart, "EmptyString");
                    //stringSuccessor += "EmptyString".Length;

                    InsertRangeIntoExpression(ref expression, ref profiles, ref stringStart, "EmptyString");

                    index = stringStart - 1;
                }
                else
                {
                    index = stringSuccessor - 1;

                    //format the piece succeeding the String
                    if (!FollowsOperandSuccessorRule(ref expression, ref profiles, index + 1))
                    {
                        throw new ArgumentException("invalid operand/operator combination found");
                    }
                }
            }
        }

        /// <summary>
        /// Analyses and formats a Char literal in the expression into a minimised format, and profiles each character in the Char literal in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the Char literal starts at</param>
        private void FormatChar(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index)
        {
            if (!FollowsCharStartRule(expression[index]))
            {
                throw new ArgumentException("the position provided isn't the start of a Char", index.ToString());
            }
            else
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, index);

                while (!FollowsCharEndRule(expression[index]))
                {
                    if (expression[index] == '\\')  //if we have an escape character, format it as such and continue
                    {
                        RemoveCharacterFromExpression(ref expression, ref profiles, index);

                        //now look at the escape character and see which escape character it is, if it's one at all
                        if (expression[index] == 'a') { ReplaceAt(ref expression, index, "\a"); }
                        else if (expression[index] == 'b') { ReplaceAt(ref expression, index, "\b"); }
                        else if (expression[index] == 'f') { ReplaceAt(ref expression, index, "\f"); }
                        else if (expression[index] == 'n') { ReplaceAt(ref expression, index, "\n"); }
                        else if (expression[index] == 'r') { ReplaceAt(ref expression, index, "\r"); }
                        else if (expression[index] == 't') { ReplaceAt(ref expression, index, "\t"); }
                        else if (expression[index] == 'v') { ReplaceAt(ref expression, index, "\v"); }
                        else if (expression[index] == '\'') { ReplaceAt(ref expression, index, "\'"); }
                        else if (expression[index] == '"') { ReplaceAt(ref expression, index, "\""); }
                        else if (expression[index] == '\\') { ReplaceAt(ref expression, index, "\\"); }
                        else { throw new ArgumentException("Unrecognised escape sequence", expression[index].ToString()); }
                    }

                    profiles[index] = FnObjectProfiles.CharBody;

                    index += 1;

                    //if we have exceeded our range, then throw exception
                    if (index >= expression.Length) { throw new ArgumentException("Char was not closed, did you forget a '?", expression.ToString()); }
                }

                //profiles[index] = FnObjectProfiles.CharEnd;
                RemoveCharacterFromExpression(ref expression, ref profiles, index);
                index -= 1;

                //format the piece succeeding the char

                if (!FollowsOperandSuccessorRule(ref expression, ref profiles, index + 1))
                {
                    throw new ArgumentException("invalid operand/operator combination found");
                }
            }
        }

        /// <summary>
        /// Analyses and formats a valid variable name in the expression into a minimised format, and profiles each character in the name in the corresponding profile list. It then uses the surrounding context to determine
        /// if the name is the name of a constant or a method call
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the name starts at</param>
        /// <param name="bracketBalance">A number which stores the current level of grouping symbols. It is the number of open brackets passed minus the number of closed brackets passed</param>
        /// <param name="methodBracketBalances">A stack which stores the bracket balances at the location of each method call</param>
        private void FormatMethodOrConstant(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index, Int32 bracketBalance, Stack<Int32> methodBracketBalances)
        {
            Int32 nameStart = index;
            Int32 nameSuccessor = index + 1;
            String name = "";

            if (!FollowsNameStartRule(expression[index]))
            {
                throw new ArgumentException("the position provided isn't the start of a method call or constant", index.ToString());
            }
            else
            {
                //set the current profile to that of Name, to be decided later whether it's a constant or a method name
                profiles[index] = FnObjectProfiles.Name;
                index += 1;

                while (index < expression.Length && FollowsNameBodyRule(expression[index]))
                {
                    profiles[index] = FnObjectProfiles.Name;
                    index += 1;
                }

                nameSuccessor = index;

                name = expression.Substring(nameStart, nameSuccessor - nameStart);

                //determine if it is a constant or a method name by looking at the succeeding characters
                if (FollowsOperandSuccessorRule(ref expression, ref profiles, index))                       //if it follows this rule it is a constant
                {
                    //check that it is a valid constant name. If not, throw and exception
                    if (!FnScriptResources.DoesConstantExist(name))
                    {
                        throw new ArgumentException("the specified constant does not exist");
                    }

                    for (int i = nameStart; i < nameSuccessor; i++)
                    {
                        profiles[i] = FnObjectProfiles.Constant;
                    }
                }
                else if (FollowsMethodNameSuccessorRule(ref expression, ref profiles, nameSuccessor))                                 //if it follows this rule it is a method name
                {
                    //check that it is a valid method name. If not, throw and exception
                    if (!FnScriptResources.DoesMethodExist(name) && name != "if")
                    {
                        throw new ArgumentException("the specified method does not exist");
                    }

                    for (int i = nameStart; i < nameSuccessor; i++)
                    {
                        profiles[i] = FnObjectProfiles.MethodName;
                    }

                    //add the method's current bracket count to the bracket balance stack
                    methodBracketBalances.Push(bracketBalance + 1);
                }
                else
                {
                    throw new ArgumentException("invalid operand/operator combination found");
                }
            }

            index = nameSuccessor - 1;
        }

        /// <summary>
        /// Analyses and formats a start grouping symbol in the expression into a minimised format, and profiles each character in the symbol in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the start grouping symbol starts at</param>
        /// <param name="bracketBalance">A number which stores the current level of grouping symbols. It is the number of open brackets passed minus the number of closed brackets passed</param>
        /// <param name="methodBracketBalances">A stack which stores the bracket balances at the location of each method call</param>
        private void FormatStartGrouping(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index, ref Int32 bracketBalance)
        {
            if (!FollowsStartGroupingRule(expression[index]))
            {
                throw new ArgumentException("The provided index does not denote an open grouping symbol", index.ToString());
            }
            else
            {
                bracketBalance += 1;

                profiles[index] = FnObjectProfiles.StartGrouping;

                //remove all whitespaces after the beginning of the start grouping
                while (index + 1 < expression.Length && expression[index + 1] == ' ')
                {
                    RemoveCharacterFromExpression(ref expression, ref profiles, index + 1);
                }

                //an opening bracket can be succeeded by an operator, another open bracket, a comma, or EOS
                if (index + 1 >= expression.Length || (FollowsEndGroupingRule(expression[index + 1]) && (profiles[index - 1] != FnObjectProfiles.MethodName)) || FollowsDivisionGroupingRule(expression[index + 1]))
                {
                    throw new ArgumentException("the open grouping symbol you have provided is in the incorrect context");
                }
            }
        }

        /// <summary>
        /// Analyses and formats a division grouping symbol in the expression into a minimised format, and profiles each character in the symbol in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the division grouping symbol starts at</param>
        /// <param name="bracketBalance">A number which stores the current level of grouping symbols. It is the number of open brackets passed minus the number of closed brackets passed</param>
        /// <param name="methodBracketBalances">A stack which stores the bracket balances at the location of each method call</param>
        private void FormatDivisionGrouping(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index, ref Int32 bracketBalance, ref Stack<Int32> methodBracketBalances)
        {
            if (!FollowsDivisionGroupingRule(expression[index]))
            {
                throw new ArgumentException("The provided index does not denote a division grouping symbol", index.ToString());
            }
            else if (methodBracketBalances.Count == 0 || bracketBalance != methodBracketBalances.Peek())
            {
                throw new ArgumentException("The division grouping symbol is in the incorrect context", expression);
            }
            else
            {
                profiles[index] = FnObjectProfiles.DivisionGrouping;

                while (index + 1 < expression.Length && expression[index + 1] == ' ')
                {
                    RemoveCharacterFromExpression(ref expression, ref profiles, index + 1);
                }

                //a division grouping symbol can be succeeded by an operator, another close bracket, a comma, or EOS
                if (index + 1 >= expression.Length || FollowsEndGroupingRule(expression[index + 1]) || FollowsDivisionGroupingRule(expression[index + 1]))
                {
                    throw new ArgumentException("the division grouping symbol you have provided is in the incorrect context");
                }
            }
        }

        /// <summary>
        /// Analyses and formats an end grouping symbol in the expression into a minimised format, and profiles each character in the symbol in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the end grouping symbol starts at</param>
        /// <param name="bracketBalance">A number which stores the current level of grouping symbols. It is the number of open brackets passed minus the number of closed brackets passed</param>
        /// <param name="methodBracketBalances">A stack which stores the bracket balances at the location of each method call</param>
        private void FormatEndGrouping(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index, ref Int32 bracketBalance, ref Stack<Int32> methodBracketBalances)
        {
            if (!FollowsEndGroupingRule(expression[index]))
            {
                throw new ArgumentException("The provided index does not denote a close grouping symbol", index.ToString());
            }
            else if (bracketBalance - 1 < 0)
            {
                throw new ArgumentException("Open/close bracket mismatch");
            }
            else
            {
                //remove unneccessary methodBracketBalances
                if (methodBracketBalances.Count > 0 && bracketBalance == methodBracketBalances.Peek())
                {
                    methodBracketBalances.Pop();
                }
                else
                {
                    if (profiles[index - 1] == FnObjectProfiles.StartGrouping)  //MOVE THIS TO START BRACKET FORMATTING
                    {
                        throw new ArgumentException("You cannot have empty brackets", expression);
                    }
                }

                bracketBalance -= 1;

                profiles[index] = FnObjectProfiles.EndGrouping;

                //remove all whitespaces after the beginning of the start grouping
                while (index + 1 < expression.Length && expression[index + 1] == ' ')
                {
                    RemoveCharacterFromExpression(ref expression, ref profiles, index + 1);
                }

                //a close bracket can be succeeded by an operator, another close bracket, a comma, or EOS
                if (index + 1 >= expression.Length || FollowsOperatorStartRule(expression[index + 1]) || FollowsEndGroupingRule(expression[index + 1]) || FollowsDivisionGroupingRule(expression[index + 1]))
                {
                }
                else
                {
                    throw new ArgumentException("the close bracket you have provided is in the incorrect context");
                }
            }
        }

        /// <summary>
        /// Analyses and formats a numeric data type in the expression into a minimised format, and profiles each character in the number in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the number starts at</param>
        private void FormatNumber(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index)
        {
            Int32 numericStart = index;
            Int32 numericSuccessor = index + 1;

            String suffix = "";
            FnObjectProfiles dataType = FnObjectProfiles.Int32;

            if (!FollowsNumericStartRule(expression[index]))
            {
                throw new ArgumentException("the position provided isn't the start of a number", index.ToString());
            }
            else
            {
                profiles[index] = FnObjectProfiles.Number;
                index += 1;

                while (index < expression.Length && FollowsNumericBodyRule(expression[index]))
                {
                    profiles[index] = FnObjectProfiles.Number;
                    if (FollowsNumericDecimalRule(expression[index])) { dataType = FnObjectProfiles.Double; }
                    index += 1;
                }

                numericSuccessor = index;

                while (index < expression.Length && FollowsNumericSuffixRule(expression[index]))
                {
                    profiles[index] = FnObjectProfiles.NumericSuffix;
                    suffix = suffix + expression[index].ToString();

                    index += 1;
                }

                if (!FollowsOperandSuccessorRule(ref expression, ref profiles, index))
                {
                    throw new ArgumentException("Invalid numeric format detected");
                }

                //now we look at the suffix we have found, determine what data type the number should have been, then redesignate the "number" tags with the correct data type, and attempt to parse the number
                //if TryParse succeeds on the data type, then we're good to go with a correctly formatted number

                switch (suffix.ToLower())
                {
                    case "":            //if we have either an Int32 or a Double, determined by the presence of a decimal point
                        {
                            break;
                        }
                    case "u":           //if we have a UInt32
                        {
                            dataType = FnObjectProfiles.UInt32;
                            break;
                        }
                    case "b":           //if we have a Byte
                        {
                            dataType = FnObjectProfiles.Byte;
                            break;
                        }
                    case "sb":          //if we have an SByte
                        {
                            dataType = FnObjectProfiles.SByte;
                            break;
                        }
                    case "s":           //if we have an Int16 (short)
                        {
                            dataType = FnObjectProfiles.Int16;
                            break;
                        }
                    case "us":          //if we have a UInt16 (unsigned short)
                        {
                            dataType = FnObjectProfiles.UInt16;
                            break;
                        }
                    case "l":           //if we have an Int64
                        {
                            dataType = FnObjectProfiles.Int64;
                            break;
                        }
                    case "ul":          //if we have a UInt64
                        {
                            dataType = FnObjectProfiles.UInt64;
                            break;
                        }
                    case "f":           //if we have a float (Single)
                        {
                            dataType = FnObjectProfiles.Single;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("the provided numeric suffix has no implementation", suffix);
                        }
                }

                //we now remove the suffix and redefine the number as the correct data type
                for (int i = 0; i < expression.Length; i++)
                {
                    if (profiles[i] == FnObjectProfiles.Number)
                    {
                        profiles[i] = dataType;
                    }
                    else if (profiles[i] == FnObjectProfiles.NumericSuffix)
                    {
                        RemoveCharacterFromExpression(ref expression, ref profiles, i);
                        i -= 1;
                    }
                }

                //try to parse the remining number and see if it works
                if (dataType == FnObjectProfiles.Byte)
                {
                    Byte output = 0;
                    if (!Byte.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.SByte)
                {
                    SByte output = 0;
                    if (!SByte.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.Int16)
                {
                    Int16 output = 0;
                    if (!Int16.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.UInt16)
                {
                    UInt16 output = 0;
                    if (!UInt16.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.Int32)
                {
                    Int32 output = 0;
                    if (!Int32.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.UInt32)
                {
                    UInt32 output = 0;
                    if (!UInt32.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.Int64)
                {
                    Int64 output = 0;
                    if (!Int64.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.UInt64)
                {
                    UInt64 output = 0;
                    if (!UInt64.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.Single)
                {
                    Single output = 0;
                    if (!Single.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else if (dataType == FnObjectProfiles.Double)
                {
                    Double output = 0;
                    if (!Double.TryParse(expression.Substring(numericStart, numericSuccessor - numericStart), out output)) { throw new ArgumentException("invalid numeric format detected", expression.Substring(numericStart, numericSuccessor - numericStart)); }
                }
                else
                {
                    throw new Exception("unacceptable numeric data type detected");
                }

                //now move index back so it is at the end of the expression
                index = numericSuccessor - 1;
            }
        }

        /// <summary>
        /// Analyses and formats a parameter in the expression into a minimised format, and profiles each character in the parameter in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the parameter starts at</param>
        private void FormatParameter(ref String expression, ref List<FnObjectProfiles> profiles, ref Dictionary<String, FnObject> parameters, ref Int32 index)
        {
            Int32 parameterStart = index;
            Int32 parameterEnd = index + 1; //just a basic initialization value

            String parameterName = "";

            if (!FollowsParameterStartRule(expression[index]))
            {
                throw new ArgumentException("The position you have specified isn't the start of a parameter", index.ToString());
            }
            else
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, index);
                //profiles[index] = FnObjectProfiles.ParameterStart;
                //index += 1;

                while (FollowsParameterBodyRule(expression[index]))
                {
                    profiles[index] = FnObjectProfiles.ParameterBody;
                    index += 1;
                }

                //see if the new character represents the end of a parameter declaration:

                if (FollowsParameterEndRule(expression[index]))
                {
                    parameterEnd = index;

                    //see if the parameter is empty. If so, throw and exception
                    //Since we removed the starting square bracket, if the parameter is empty, it the end bracket will be in the same place as the start bracket
                    if (parameterEnd - parameterStart == 0)
                    {
                        throw new ArgumentException("Empty parameter detected, every parameter must have a name");
                    }
                    else
                    {
                        if (FollowsOperandSuccessorRule(ref expression, ref profiles, index + 1))
                        {
                            //profiles[index] = FnObjectProfiles.ParameterEnd;
                            RemoveCharacterFromExpression(ref expression, ref profiles, index);
                            index -= 1;

                            //now check that the parameter is listed in either the local, collection or global lists
                            parameterName = expression.Substring(parameterStart, parameterEnd - parameterStart);

                            if (!parameters.ContainsKey(parameterName))
                            {
                                throw new ArgumentException("The parameter has not been declared in any of the parameter accessibility lists", parameterName);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Invalid Operator/Operand border detected");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid parameter syntax detected");
                }
            }
        }

        /// <summary>
        /// Analyses and formats an operator in the expression into a minimised format, and profiles each character in the operator in the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The list of profiles for each character</param>
        /// <param name="index">The index the operator starts at</param>
        private void FormatOperator(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 index)
        {
            Int32 operatorStart = index;
            Int32 operatorSuccessor = index + 1;

            String operatorString = "";

            if (!FollowsOperatorStartRule(expression[index]))
            {
                throw new ArgumentException("The position you have defined is not the start of an operator", index.ToString());
            }
            else
            {
                //we have landed on the start of an operator, profile the character and loop through until we find a character that is not an operator
                profiles[index] = FnObjectProfiles.Operator;
                index += 1;

                while (index < expression.Length && FollowsOperatorBodyRule(expression[index]))
                {
                    profiles[index] = FnObjectProfiles.Operator;
                    index += 1;
                }

                operatorString = expression.Substring(operatorStart, index - operatorStart);

                //now that we have the extent of our operator, we must check that either it, or a subset of it is actually a valid operator
                while (!BinaryOperators.Contains(operatorString) && !UnaryPrefixOperators.Contains(operatorString) && !UnarySuffixOperators.Contains(operatorString))
                {
                    profiles[index] = FnObjectProfiles.Unassessed;
                    index -= 1;
                    operatorString = expression.Substring(operatorStart, index - operatorStart);
                }

                operatorSuccessor = index;

                //now we need to decide if it is a unaryPrefix, unarySuffix or Binary operator based on the context it is in.
                //To have a valid operator, it has to be in the correct context and has to be listed as that particular type of operator

                //if both those conditions aren't met, throw an exception

                if (FollowsBinarySurroundingRules(ref expression, ref profiles, operatorStart, operatorSuccessor) && BinaryOperators.Contains(operatorString))  //if we have a binary operator
                {
                    for (int i = operatorStart; i < operatorSuccessor; i++)
                    {
                        profiles[i] = FnObjectProfiles.BinaryOperator;
                    }
                }
                else if (FollowsUnaryPrefixSurroundingRules(ref expression, ref profiles, operatorStart, operatorSuccessor) && UnaryPrefixOperators.Contains(operatorString))                                                                                                                                       //if we have a unary prefix operator
                {
                    for (int i = operatorStart; i < operatorSuccessor; i++)
                    {
                        profiles[i] = FnObjectProfiles.UnaryPrefixOperator;
                    }
                }
                else if (FollowsUnarySuffixSurroundingRules(ref expression, ref profiles, operatorStart, operatorSuccessor) && UnarySuffixOperators.Contains(operatorString))                                                                                                                                         //if we have a unary suffix operator
                {
                    for (int i = operatorStart; i < operatorSuccessor; i++)
                    {
                        profiles[i] = FnObjectProfiles.UnarySuffixOperator;
                    }
                }
                else
                {
                    throw new ArgumentException("The operator provided is in the incorrect context", operatorString);
                }

                for (int i = operatorSuccessor; i < expression.Length; i++)
                {
                    profiles[i] = FnObjectProfiles.Unassessed;
                }

                index = operatorSuccessor - 1;
            }
        }

        /// <summary>
        /// Inserts a string into an FnScript expression at a specified start location, and also inserts the necessary profile tokens into the corresponding profile list. Inserted tokens default to a value of Unassessed
        /// </summary>
        /// <param name="expression">The FnScript expression in string frm</param>
        /// <param name="profiles">The corresponding list of profiles for each character in the expression</param>
        /// <param name="startIndex">The index to perform the insertion at</param>
        /// <param name="insertString">The string to insert at the specified start index</param>
        private void InsertRangeIntoExpression(ref String expression, ref List<FnObjectProfiles> profiles, ref Int32 startIndex, String insertString)
        {
            expression = expression.Insert(startIndex, insertString);

            List<FnObjectProfiles> insertProfiles = new List<FnObjectProfiles>(insertString.Length);
            for (int i = 0; i < insertString.Length; i++)
            {
                insertProfiles.Add(FnObjectProfiles.Unassessed);
            }

            profiles.InsertRange(startIndex, insertProfiles);
        }

        /// <summary>
        /// Replaces a given character in an expression string with another specified character
        /// </summary>
        /// <param name="expression">The fnScript expression in string form</param>
        /// <param name="index">The index to replace the character at</param>
        /// <param name="newCharacter">The new character to replace the existing character with</param>
        private void ReplaceAt(ref String expression, Int32 index, String newCharacter)
        {
            expression = expression.Remove(index, 1);
            expression = expression.Insert(index, newCharacter);
        }

        /// <summary>
        /// Removes a character from an expression stringm, and removes its profile from the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The corresponding profiles for each character in the expression string</param>
        /// <param name="index">The index to remove from the expression and profile list</param>
        private void RemoveCharacterFromExpression(ref String expression, ref List<FnObjectProfiles> profiles, Int32 index)
        {
            expression = expression.Remove(index, 1);
            profiles.RemoveAt(index);
        }

        /// <summary>
        /// Removes a range of characters from an expression string, and removes their profiles from the corresponding profile list
        /// </summary>
        /// <param name="expression">The expression in string form</param>
        /// <param name="profiles">The corresponding profiles for each expression character</param>
        /// <param name="startIndex">The index to start removing from</param>
        /// <param name="endIndex">The last index to remove</param>
        private void RemoveCharacterRangeFromExpression(ref String expression, ref List<FnObjectProfiles> profiles, Int32 startIndex, Int32 endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                RemoveCharacterFromExpression(ref expression, ref profiles, startIndex);
            }
        }

        #endregion

        #region Add to Execution Tree Methods

        /// <summary>
        /// Detects an operator from the desired position in an expression and adds it to the execution tree
        /// </summary>
        /// <param name="expression">The expression containing the constant</param>
        /// <param name="profiles">The list of object profiles for the entire expression</param>
        /// <param name="index">The starting character position for the operator</param>
        private void AddOperatorToExecutionTree(String expression, List<FnObjectProfiles> profiles, ref Int32 index, ref Stack<String> operatorStack, ref Stack<FnObjectProfiles> operatorProfileStack, ref List<FnObject> executionList, ref List<Boolean> isBound, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
        {
            Int32 operatorStart = index;
            Int32 operatorSuccessor;

            String operatorName;

            while (index < expression.Length && profiles[index] == profiles[operatorStart])
            {
                index += 1;
            }

            operatorSuccessor = index;
            index -= 1;

            operatorName = expression.Substring(operatorStart, operatorSuccessor - operatorStart);

            while (operatorStack.Count != 0 && (GetOperatorPrecedence(operatorStack.Peek(), operatorProfileStack.Peek()) >= GetOperatorPrecedence(operatorName, profiles[operatorStart])))
            {
                PopOperatorToExecutionTree(ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
            }

            operatorStack.Push(operatorName);
            operatorProfileStack.Push(profiles[operatorStart]);
        }

        /// <summary>
        /// Pops operators from the operator stack and adds them to the execution tree in the appropriate order
        /// </summary>
        /// <param name="operatorStack">The stack containing the operators</param>
        /// <param name="operatorProfileStack">The stack containing the profiles for these operators</param>
        private void PopOperatorToExecutionTree(ref Stack<String> operatorStack, ref Stack<FnObjectProfiles> operatorProfileStack, ref List<FnObject> ExecutionList, ref List<Boolean> IsBound, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
        {
            if (operatorProfileStack.Peek() == FnObjectProfiles.BinaryOperator)
            {
                Int32 secondOperatorIndex = GetNextUnBoundIndex(ref IsBound);
                IsBound[secondOperatorIndex] = true;
                Int32 firstOperatorIndex = GetNextUnBoundIndex(ref IsBound);
                IsBound[firstOperatorIndex] = true;

                ExecutionList.Add(GetOperatorMethod(operatorStack.Pop(), operatorProfileStack.Pop(), new List<FnObject> { ExecutionList[firstOperatorIndex], ExecutionList[secondOperatorIndex] }, parameters, isPreExecute));
            }
            else                //Unary prefix and unary suffix operators obey the same rule
            {
                Int32 firstOperatorIndex = GetNextUnBoundIndex(ref IsBound);
                IsBound[firstOperatorIndex] = true;

                ExecutionList.Add(GetOperatorMethod(operatorStack.Pop(), operatorProfileStack.Pop(), new List<FnObject> { ExecutionList[firstOperatorIndex] }, parameters, isPreExecute));
            }

            IsBound.Add(false);
        }

        /// <summary>
        /// Detects a literal from the desired position in an expression and adds it to the execution tree
        /// </summary>
        /// <param name="expression">The expression containing the constant</param>
        /// <param name="profiles">The list of object profiles for the entire expression</param>
        /// <param name="index">The starting character position for the literal</param>
        private void AddLiteralToExecutionTree(String expression, List<FnObjectProfiles> profiles, ref List<FnObject> ExecutionList, ref List<Boolean> IsBound, ref  Int32 index)
        {
            Int32 literalStart = index;
            Int32 literalSuccessor;
            String literal;

            while (index < profiles.Count && IsLiteralTypeProfile(profiles[index]))
            {
                index += 1;
            }

            literalSuccessor = index;
            index -= 1;

            literal = expression.Substring(literalStart, literalSuccessor - literalStart);

            if (profiles[literalStart] == FnObjectProfiles.Byte)
            {
                ExecutionList.Add(new FnConstant<Byte>(Byte.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.SByte)
            {
                ExecutionList.Add(new FnConstant<SByte>(SByte.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.Int16)
            {
                ExecutionList.Add(new FnConstant<Int16>(Int16.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.UInt16)
            {
                ExecutionList.Add(new FnConstant<UInt16>(UInt16.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.Int32)
            {
                ExecutionList.Add(new FnConstant<Int32>(Int32.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.UInt32)
            {
                ExecutionList.Add(new FnConstant<UInt32>(UInt32.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.Int64)
            {
                ExecutionList.Add(new FnConstant<Int64>(Int64.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.UInt64)
            {
                ExecutionList.Add(new FnConstant<UInt64>(UInt64.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.Single)
            {
                ExecutionList.Add(new FnConstant<Single>(Single.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.Double)
            {
                ExecutionList.Add(new FnConstant<Double>(Double.Parse(literal)));
            }
            else if (profiles[literalStart] == FnObjectProfiles.StringBody)
            {
                ExecutionList.Add(new FnConstant<String>(literal));
            }
            else if (profiles[literalStart] == FnObjectProfiles.CharBody)
            {
                ExecutionList.Add(new FnConstant<Char>(Convert.ToChar(literal)));
            }
            else
            {
                throw new ArgumentException("The data type you have specified isn't a number");
            }

            IsBound.Add(false);
        }

        /// <summary>
        /// Detects a parameter from the desired position in an expression and adds it to the execution tree
        /// </summary>
        /// <param name="expression">The expression containing the constant</param>
        /// <param name="profiles">The list of object profiles for the entire expression</param>
        /// <param name="index">The starting character position for the parameter</param>
        private void AddParameterInstanceToExecutionTree(String expression, List<FnObjectProfiles> profiles, ref Dictionary<String, FnObject> parameters, ref List<FnObject> executionList, ref List<Boolean> isBound, ref Int32 index)
        {
            Int32 parameterStart = index;
            Int32 parameterSuccessor;
            String parameterName;

            while (index < profiles.Count && profiles[index] == FnObjectProfiles.ParameterBody)
            {
                index += 1;
            }

            parameterSuccessor = index;
            index -= 1;

            parameterName = expression.Substring(parameterStart, parameterSuccessor - parameterStart);

            AddParameterToExecutionTree(parameterName, ref parameters, ref executionList);
            isBound.Add(false);
        }

        /// <summary>
        /// Detects a constant from the desired position in an expression and adds it to the execution tree
        /// </summary>
        /// <param name="expression">The expression containing the constant</param>
        /// <param name="profiles">The list of object profiles for the entire expression</param>
        /// <param name="index">The starting character position for the constant</param>
        private void AddConstantToExecutionTree(String expression, List<FnObjectProfiles> profiles, ref List<FnObject> ExecutionList, ref List<Boolean> IsBound, ref Int32 index)
        {
            Int32 constantStart = index;
            Int32 constantSuccessor;
            String constantName;

            while (index < profiles.Count && profiles[index] == FnObjectProfiles.Constant)
            {
                index += 1;
            }

            constantSuccessor = index;
            index -= 1;

            constantName = expression.Substring(constantStart, constantSuccessor - constantStart);

            //we have already determined the constant exists in syntax checking, we can go straight ahead and add it
            ExecutionList.Add(FnScriptResources.GetConstant(constantName));
            IsBound.Add(false);
        }

        /// <summary>
        /// Detects the method call from the desired position in an expression and adds the method to the execution tree
        /// </summary>
        /// <param name="expression">The expression containing the method</param>
        /// <param name="profiles">The list of object profiles for the entire expression</param>
        /// <param name="index">The starting character position for the method call</param>
        private void AddMethodToExecutionTree(String expression, List<FnObjectProfiles> profiles, ref Dictionary<String, FnObject> parameters, ref List<FnObject> executionList, ref List<Boolean> isBound, ref Int32 index, FnVariable<Boolean> isPreExecute)
        {
            Int32 methodNameStart = index;
            Int32 methodNameSuccessor;
            String methodName;

            List<FnObject> compiledMethodArguments = new List<FnObject>();

            while (index < profiles.Count && profiles[index] == FnObjectProfiles.MethodName)
            {
                index += 1;
            }

            methodNameSuccessor = index;

            methodName = expression.Substring(methodNameStart, methodNameSuccessor - methodNameStart);

            Int32 bracketLevel = 0;
            Int32 argumentStart = methodNameSuccessor + 1;
            Int32 argumentSuccessor;

            //loop through the arguments, pick out each one and compile it
            while (true)
            {
                //edit the bracket level to determine where we are
                if (profiles[index] == FnObjectProfiles.StartGrouping)
                {
                    bracketLevel += 1;
                }
                else if (profiles[index] == FnObjectProfiles.EndGrouping)
                {
                    bracketLevel -= 1;
                }

                //if we just passed the end of an argument
                if ((profiles[index] == FnObjectProfiles.DivisionGrouping && bracketLevel == 1) || bracketLevel == 0)
                {
                    argumentSuccessor = index;


                    if (argumentSuccessor - argumentStart > 0)
                    {
                        //get the profiles for the argument
                        List<FnObjectProfiles> argumentProfiles = new List<FnObjectProfiles>(argumentSuccessor - argumentStart);
                        for (int i = argumentStart; i < argumentSuccessor; i++)
                        {
                            argumentProfiles.Add(profiles[i]);
                        }

                        ConvertToExecutionTree(expression.Substring(argumentStart, argumentSuccessor - argumentStart), argumentProfiles, ref parameters, ref executionList, ref isBound, isPreExecute);
                        compiledMethodArguments.Add(executionList.Last());
                        isBound[isBound.Count - 1] = true;
                    }

                    //set up argumentStart for the next argument
                    argumentStart = argumentSuccessor + 1;
                }

                //if our bracket level is now 0, get out of the loop
                if (bracketLevel == 0)
                {
                    break;
                }

                index += 1;
            }

            if (methodName == "if")                //If it's a conditional argument, then create a method pointer using one of the "return" arguments, either 1 or 2, depending on which one has the higher type precedence
            {
                //figure out which return type has the highest precedence
                if (FnScriptResources.TypePrecedence[compiledMethodArguments[1].GetWrappedObjectType()] > FnScriptResources.TypePrecedence[compiledMethodArguments[2].GetWrappedObjectType()])
                {
                    //ExecutionList.Add(compiledMethodArguments[1].CreateConditionalFnObjectWithSameType(compiledMethodArguments));

                    if (FnScriptResources.ImplicitConversionSwitches.ContainsKey(compiledMethodArguments[1].GetWrappedObjectType()))
                    {
                        executionList.Add(FnScriptResources.ImplicitConversionSwitches[compiledMethodArguments[1].GetWrappedObjectType()].CreateObjectWithPointer(new List<FnObject> { compiledMethodArguments[2] }, parameters, isPreExecute));
                        isBound[isBound.Count - 1] = true;
                        isBound.Add(false);

                        compiledMethodArguments[2] = executionList.Last();
                    }
                    else
                    {
                        throw new ArgumentException("The output type of the expression doesn't match the specified return type", expression);   //This is the WRONG exception message
                    }

                }
                else if (FnScriptResources.TypePrecedence[compiledMethodArguments[2].GetWrappedObjectType()] > FnScriptResources.TypePrecedence[compiledMethodArguments[1].GetWrappedObjectType()])
                {
                    if (FnScriptResources.ImplicitConversionSwitches.ContainsKey(compiledMethodArguments[2].GetWrappedObjectType()))
                    {
                        executionList.Add(FnScriptResources.ImplicitConversionSwitches[compiledMethodArguments[2].GetWrappedObjectType()].CreateObjectWithPointer(new List<FnObject> { compiledMethodArguments[1] }, parameters, isPreExecute));
                        isBound[isBound.Count - 1] = true;
                        isBound.Add(false);

                        compiledMethodArguments[1] = executionList.Last();
                    }
                    else
                    {
                        throw new ArgumentException("The output type of the expression doesn't match the specified return type", expression);   //This is the WRONG exception message
                    }
                }

                executionList.Add(compiledMethodArguments[1].CreateFnIfWithSameType(compiledMethodArguments[0] as FnObject<bool>, compiledMethodArguments[1], compiledMethodArguments[2]));

                isBound.Add(false);
            }
            else
            {
                executionList.Add(FnScriptResources.FnMethods[methodName].CreateObjectWithPointer(compiledMethodArguments, parameters, isPreExecute));
                isBound.Add(false);
            }
        }

        /// <summary>
        /// Adds a parameter of the specified name to the execution tree. It uses the parameter in the lowest level of publicity
        /// </summary>
        /// <param name="parameterName">The name of the parameter to add to the execution tree</param>
        private void AddParameterToExecutionTree(String parameterName, ref Dictionary<String, FnObject> parameters, ref List<FnObject> executionList)
        {
            //check the aggregated parameters dictionary. If it isn't in any, then throw an exception

            if (parameters.ContainsKey(parameterName))
            {
                executionList.Add(parameters[parameterName]);
            }
            else
            {
                throw new ArgumentException("the specified parameter does not exist");
            }
        }

        /// <summary>
        /// Returns the precedence of the operator from the list of operator precedences
        /// </summary>
        /// <param name="operatorName">The operator in string format</param>
        /// <param name="operatorProfile">The profile for the operator, be it UnaryPrefixOperator, UnarySuffixOperator, or BinaryOperator</param>
        /// <returns></returns>
        private Int32 GetOperatorPrecedence(String operatorName, FnObjectProfiles operatorProfile)
        {
            if (operatorProfile == FnObjectProfiles.BinaryOperator)
            {
                return BinaryOperatorPrecedence[operatorName];
            }
            else if (operatorProfile == FnObjectProfiles.UnaryPrefixOperator)
            {
                return UnaryPrefixOperatorPrecedence[operatorName];
            }
            else if (operatorProfile == FnObjectProfiles.UnarySuffixOperator)
            {
                return UnarySuffixOperatorPrecedence[operatorName];
            }
            else if (operatorName == "(")
            {
                return -1;
            }
            else if (operatorName == ")")
            {
                return -1;
            }

            //not sure if this will work, should do
            return -1;
        }

        /// <summary>
        /// Returns an FnObject storing the method that corresponds with the operator provided
        /// </summary>
        /// <param name="operatorString">The operator to analyse, in string format</param>
        /// <param name="operatorProfile">The profile for this operator, be it UnaryPrefixOperator, UnarySuffixOperator or BinaryOperator</param>
        /// <param name="operands">A list of operands that this operator uses. These are used as method parameters in the returned FnObject</param>
        /// <returns></returns>
        private FnObject GetOperatorMethod(String operatorString, FnObjectProfiles operatorProfile, List<FnObject> operands, Dictionary<String, FnObject> parameters, FnVariable<Boolean> isPreExecute)
        {
            if (operatorProfile == FnObjectProfiles.UnaryPrefixOperator)
            {
                if (operatorString == "+")
                {
                    return FnScriptResources.FnMethods["Positive"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "-")
                {
                    return FnScriptResources.FnMethods["Negative"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "!")
                {
                    return FnScriptResources.FnMethods["Not"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
            }
            else if (operatorProfile == FnObjectProfiles.UnarySuffixOperator)
            {
            }
            else if (operatorProfile == FnObjectProfiles.BinaryOperator)
            {
                if (operatorString == "+")
                {
                    return FnScriptResources.FnMethods["Add"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "-")
                {
                    return FnScriptResources.FnMethods["Subtract"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "*")
                {
                    return FnScriptResources.FnMethods["Multiply"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "/")
                {
                    return FnScriptResources.FnMethods["Divide"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "%")
                {
                    return FnScriptResources.FnMethods["Mod"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == ">")
                {
                    return FnScriptResources.FnMethods["IsGreaterThan"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == ">=")
                {
                    return FnScriptResources.FnMethods["IsGreaterThanOrEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "<")
                {
                    return FnScriptResources.FnMethods["IsLessThan"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "<=")
                {
                    return FnScriptResources.FnMethods["IsLessThanOrEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "==")
                {
                    return FnScriptResources.FnMethods["IsEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "!=")
                {
                    return FnScriptResources.FnMethods["IsNotEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "&&")
                {
                    return FnScriptResources.FnMethods["And"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "!&&")
                {
                    return FnScriptResources.FnMethods["Nand"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "||")
                {
                    return FnScriptResources.FnMethods["Or"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "!||")
                {
                    return FnScriptResources.FnMethods["Nor"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                else if (operatorString == "^")
                {
                    return FnScriptResources.FnMethods["Xor"].CreateObjectWithPointer(operands, parameters, isPreExecute);
                }
                //This is where we will add XNor, at the end of FnScript 2.2 upgrade
            }

            throw new ArgumentException("This operator is not supported", operatorString);
        }

        /// <summary>
        /// Returns the index of the next unbound FnObject in the Execution Tree
        /// </summary>
        /// <returns></returns>
        private int GetNextUnBoundIndex(ref List<Boolean> IsBound)
        {
            int index = IsBound.Count - 1;

            while (index >= 0 && IsBound[index])
            {
                index -= 1;
            }

            return index;
        }

        #endregion
    }
}
