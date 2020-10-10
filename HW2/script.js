let listOneRadioBtn = false;
let listTwoRadioBtn = false;
let listOneDiv = ".listOne";
let listTwoDiv = ".listTwo";


function makeTaskElement (input, listName) {
    let list = $(listName);
    list.append(`
    <div class="task">
        <div class="text">
            <p>${input}</p>
        </div>
    <div>
        <button type="button" class="completeBtn" id="completeBtn">
            <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-check" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                <path fill-rule="evenodd" d="M10.97 4.97a.75.75 0 0 1 1.071 1.05l-3.992 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.236.236 0 0 1 .02-.022z"/>
            </svg>
        </button>
    </div>
</div>`).hide().fadeIn(250);

}

$('#listOneBtn').click(function() {
    listOneRadioBtn = true;
    listTwoRadioBtn = false;

    console.log(listOneRadioBtn, listTwoRadioBtn);
})
$('#listTwoBtn').click(function() {
    listOneRadioBtn = false;
    listTwoRadioBtn= true;

    console.log(listOneRadioBtn, listTwoRadioBtn);

})



$('#addButton').click(function() {
    let userInput = $('#userInput').val();
    console.log(userInput);

    let list1 = $('.listOne');
    let list2 = $('.listTwo');

    if(listOneRadioBtn == false && listTwoRadioBtn == false || userInput == '') {
        if(userInput == '') {
            alert("Please enter a task");
        }
        else
            alert("Please choose a list");
    }
    else {

        if(listOneRadioBtn == true && listTwoRadioBtn == false) {
            $('#emptyListOne').fadeOut(500);

            list1.delay(1000).queue(function(next) {

                list1.append(makeTaskElement(userInput, listOneDiv));
                next();
            })
        }
        else if(listTwoRadioBtn == true && listOneRadioBtn == false) {
            $('#emptyListTwo').fadeOut(500);

            list2.delay(1000).queue(function(next) {
                list2.append(makeTaskElement(userInput, listTwoDiv));
                next();
            })
        }
    listOneRadioBtn = false;
    listTwoRadioBtn = false;
    $('#userInput').val('');
    }
})

$(document).on('click', '.completeBtn', function() {
    $(this).parent().parent().css({'text-decoration': 'line-through'});

    $(this).delay(500).queue(function(next) {
        $(this).parent().parent().fadeOut(1000);
        next()
    }); 
})