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

// início código tela de dúvidas - acordeon

var accItem = document.getElementsByClassName('accordionItem');
var accHD = document.getElementsByClassName('accordionItemHeading');
for (i = 0; i < accHD.length; i++) {
    accHD[i].addEventListener('click', toggleItem, false);
}
function toggleItem() {
    var itemClass = this.parentNode.className;
    for (i = 0; i < accItem.length; i++) {
        accItem[i].className = 'accordionItem close';
    }
    if (itemClass == 'accordionItem close') {
        this.parentNode.className = 'accordionItem open';
    }
}

// final código tela de dúvidas - acordeon

// início código tela de como funciona - carrossel
var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
  showSlides(slideIndex += n);
}

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
// final código tela de como funciona - carrossel