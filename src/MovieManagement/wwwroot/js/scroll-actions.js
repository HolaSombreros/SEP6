function ScrollRight(Element, Width) {
    document.getElementById(Element).scrollBy({
        top: 0, left: Width * Math.floor((document.getElementById(Element).offsetWidth / Width)), behavior: "smooth"
    })
}
function ScrollLeft(Element, Width) {
    document.getElementById(Element).scrollBy({
        top: 0, left: -Width * Math.floor((document.getElementById(Element).offsetWidth / Width)), behavior: "smooth"
    })
}