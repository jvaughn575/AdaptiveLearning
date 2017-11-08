var MathQuizModule = (function (mathQuizParams = null, savedQuizQuestions = null, id = null) {  
    
    
    // if savedQuizQuestions is provided this variable will store the list of questions
    var numQuestions;
    var mathQuizResultJsonData;

    if (savedQuizQuestions) {
        questions = savedQuizQuestions.split(' ');
        questions = questions.filter(entry => entry.trim() != '');
        questions.reverse();        
        numQuestions = questions.length;
        console.log("Questions saved", questions);
    }
    

    var getRandom = function (min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1)) + min;
    };

    if (mathQuizParams) {

        mathQuizResultJsonData = {
            quiz: { questions: "", created: (new Date()).toISOString() },
            result: { points: "", secsperquestion: "" , created: (new Date()).toISOString() }
        };
    }
    else if (savedQuizQuestions && id){
        mathQuizResultJsonData = {            
            result: { points: "", secsperquestion: "", SavedMathQuizID: id, created:(new Date()).toISOString() }
        };
    }

    var generateQuestion = function () {

        if (mathQuizParams) {

            numQuestions = mathQuizParams.numQuestions;
            var num1 = getRandom(mathQuizParams.number1LowRange, mathQuizParams.number1HighRange);
            var num2 = getRandom(mathQuizParams.number2LowRange, mathQuizParams.number2HighRange);
            var operator = mathQuizParams.operations[getRandom(0, mathQuizParams.operations.length - 1)];
        }
        else if (savedQuizQuestions) {
            var questionString = questions.pop();
            var operator;
            if (questionString.includes("&#x2B;")) {
                operator = "&#x2B;";
            }
            else if (questionString.includes("x")) {
                operator = "x";
            }
            else if (questionString.includes("-")) {
                operator = "-";
            }

            
           // var [num1, num2] = questionString.split(operator);
            var splitString = questionString.split(operator);
            var num1 = splitString[0];
            var num2 = splitString[1];
            
            

        }

        // Make sure the biggest number is on top
        if (num2 > num1) {
            var temp = num2;
            num2 = num1;
            num1 = temp;
        }

        return { num1: num1, num2: num2, operator: operator };
    };

    var loadQuestion = function () {
        var question = generateQuestion();


        var mathExpression = "\\begin{array}{r}&" + question.num1 + "\\\\" + question.operator + "\\!\\!\\!\\!\\!\\!&" + question.num2 + "\\\\\\hline\\end{array}";
        mathExpression = mathExpression.replace("&#x2B;", "+");


        MathJax.Hub.Queue(function () {
            var math = MathJax.Hub.getAllJax("math-quiz")[0];            
            MathJax.Hub.Queue(["Text", math, mathExpression]);
        }
        );
        var math = document.getElementById("#math-quiz");

        return question;
    };

    // &#x2B; is html encoded representation of the '+' symbol
    var operatorFuncArr = {
        '&#x2B;': function (a, b) {
            return a + b;
        },
        'x': function (a, b) {
            return a * b;
        },
        '-': function (a, b) {
            return a - b;
        },
        '/': function (a, b) {
            return a / b;
        }
    };

    // Start

    var question = loadQuestion();
    var startTime = Date.now();
    var endTime;

    const Emotion = {
        Contempt: 'Contempt',
        Disgust: 'Disgust',
        Fear: 'Fear',
        Happiness: 'Happiness',
        Neutral: 'Neutral',
        Sadness: 'Sadness',
        Surprise: 'Surprise'
    }

    $("#math-quiz-line-3").on('keyup', function (e) {
        if (e.keyCode == 13) { // enter key
            endTime = Date.now();

            var correct_answer = operatorFuncArr[question.operator](question.num1, question.num2);
            //console.log("Answer is:", correct_answer);

            if (correct_answer == event.target.value) {
                // 1 in the arr represents a correct answer
                mathQuizResultJsonData.result.points += (1).toString() + " ";
            }
            else {
                mathQuizResultJsonData.result.points += (0).toString() + " ";
            }

            if (mathQuizParams) {
                mathQuizResultJsonData.quiz.questions += question.num1 + question.operator + question.num2 + " ";
            }
            
            mathQuizResultJsonData.result.secsperquestion += ((endTime - startTime) / 1000).toString() + " ";

            
            if ((mathQuizResultJsonData.result.points.split(" ").length - 1) == numQuestions) {

                if (mathQuizParams) {
                    $.ajax({
                        url: "/MathQuiz/PostJson",
                        type: "POST",
                        data: mathQuizResultJsonData,
                        success: function (data) {
                            if (data.state == 0) {
                                document.location = "/MathQuiz/PostJson";

                            }
                        }
                    });
                }
                else if (savedQuizQuestions && id) {
                    $.ajax({
                        url: "/MathQuiz/PostJsonResult",
                        type: "POST",
                        data: mathQuizResultJsonData,
                        success: function (data) {
                            if (data.state == 0) {
                                document.location = "/MathQuiz/Details/" + id;

                            }
                        }
                    });
                }

            }
            else {
                // Reset text box and load next question
                $('#math-quiz-line-3').val('');
                question = loadQuestion();
                startTime = Date.now();
            }



        }
    
    });

        return {
        
        }; 

});