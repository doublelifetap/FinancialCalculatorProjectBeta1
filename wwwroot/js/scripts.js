
function plusSlides(n) {
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {

  // Improve ugly logic
  var i;
  var slides = document.getElementsByClassName("slide");
  var dots = document.getElementsByClassName("dot");
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
  }

  for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
  }

  slides[slideIndex-1].style.display = "flex";
  dots[slideIndex-1].className += " active";
}

function executeNextSlide() {

    plusSlides(1);
    setTimeout(executeNextSlide, 10000);
}

showSlides(slideIndex);
setTimeout(executeNextSlide, 10000);

$(document).ready(function(){
    $("#formButton").click(function(){
        $("#form1").hide();
    });
});
