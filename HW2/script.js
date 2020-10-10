let listOneRadioBtn = false;
let listTwoRadioBtn = false;
let listOneDiv = ".listOne";
let listTwoDiv = ".listTwo";


function makeTaskElement (input, listName) {
    let list = $(listName);
    list.append(`<p>${input}</p>`).hide().fadeIn(250);

}



$('#addButton').click(function() {
    let userInput = $('#userInput').val();
    console.log(userInput);

    let list1 = $('.listOne');
    let list2 = $('.listTwo');

    if(listOneRadioBtn == false && listTwoRadioBtn == false) {
        alert("Make decision");
    }
    else {

        if(listOneRadioBtn == false && listTwoRadioBtn == false) {
            $('#emptyListOne').fadeOut(500);

            list1.delay(1000).queue(function(next) {

                list1.append(makeTaskElement(userInput, listOneDiv));
                next();
            })
        }
        else if(listTwoRadioBtn == true && listOneRadioBtn == false) {
            $('#emptyListTwo').fadeOut(500);

            list2.delay(3000).queue(function(next) {
                list2.append(makeTaskElement(userInput, listTwoDiv));
                next();
            })
        }
    listOneRadioBtn = false;
    listTwoRadioBtn = false;
    }
})