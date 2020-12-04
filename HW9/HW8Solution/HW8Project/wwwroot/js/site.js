// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('select').each(function () {
      $(this).select2({
        theme: 'bootstrap4',
        width: $(this).data('width') ? $(this).data('width') : $(this).hasClass('w-100') ? '100%' : 'style',
        placeholder: $(this).data('placeholder'),
        allowClear: Boolean($(this).data('allow-clear')),
      });
    });
  });


  $('#AddTag').click(function () {
    console.log("Clicked");
    var input = $('#textBox').val();
    var address = 'AddTag';

    $.ajax({
        url: address,
        data: {tags : input},
        type: "POST",
        success: successFunction(),
        error: errorOnAjax()
    });
});

function successFunction()
{
  console.log("GOOD");
  // alert("Successful");
  setTimeout(() => {  window.location.assign(document.URL); }, 250);
}
function errorOnAjax()
{
  console.log("ERROR");
}