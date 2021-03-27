$("#submitButton").click( function () {

    //Initialize variables
    let fAssignments = parseFloat($("#assignments").val());
    let fGroup_proj = parseFloat($("#grpproj").val());
    let fQuizzes = parseFloat($("#quizzes").val());
    let fExams = parseFloat($("#exams").val());
    let fIntex = parseFloat($("#intex").val());
    let fFinalGrade = ((fAssignments * .5) + (fGroup_proj * .1) + (fQuizzes * .1) + (fExams * .2) + (fIntex * .1));
    let sLetterGrade = "";

    //Determine grade
    if (fFinalGrade >= 93) {
        sLetterGrade = "A";
    }
    else if(fFinalGrade >= 90) {
        sLetterGrade = "A-";
    }
    else if (fFinalGrade >= 87) {
        sLetterGrade = "B+";
    }
    else if (fFinalGrade >= 83) {
        sLetterGrade = "B";
    }
    else if (fFinalGrade >= 80) {
        sLetterGrade = "B-";
    }
    else if (fFinalGrade >= 77) {
        sLetterGrade = "C+";
    }
    else if (fFinalGrade >= 73) {
        sLetterGrade = "C";
    }
    else if (fFinalGrade >= 70) {
        sLetterGrade = "C-";
    }
    else if (fFinalGrade >= 67) {
        sLetterGrade = "D+";
    }
    else if (fFinalGrade >= 63) {
        sLetterGrade = "D";
    }
    else if (fFinalGrade >= 60) {
        sLetterGrade = "D-";
    }
    else if (fFinalGrade >= 0) {
        sLetterGrade = "E";
    }

    //Pop-up on screen
    alert("You received a final grade of " + fFinalGrade.toFixed(1) + "%. This leaves you with a(n) " + sLetterGrade + ".");
});