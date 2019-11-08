const helloWorld = 
`
.o88b.  .d88b.  d8888b. d88888b   db    db d8888b.
d8P  Y8 .8P  Y8. 88   8D 88'        8b  d8' 88  8D
8P      88    88 88   88 88ooooo     8bd8'  88oodD'
8b      88    88 88   88 88         .dPYb.  88  
Y8b  d8  8b  d8' 88  .8D 88.       .8P  Y8. 88     
  Y88P'   Y88P'  Y8888D' Y88888P   YP    YP 88    
`; 


console.log(helloWorld); 

var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
  showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("dot");
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " active";
}