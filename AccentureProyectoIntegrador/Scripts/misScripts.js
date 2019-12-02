//let main = document.querySelector("main")
//let btns = document.querySelectorAll(".boton")

let btn = document.querySelector(".material-icons")
let main = document.querySelector("main");

btn.addEventListener("click", () => {
    if (document.getElementById("nav").className != 'abierto') {
        document.getElementById("nav").classList.add('abierto')
    } else {
        document.getElementById("nav").classList.remove('abierto')
    }
})

let enlaces = document.querySelectorAll(".link")

enlaces.forEach(enlace => {
    enlace.addEventListener("click", e => {
        e.preventDefault()
        ajax(`${e.target.dataset.archivo}.html`)
        document.getElementById("nav").classList.remove('abierto')
    })
})

function ajax(url) {
    let xhr = new XMLHttpRequest
    xhr.open("GET", url)
    xhr.addEventListener("readystatechange", () => {
        if (xhr.readyState == 4 && xhr.status == 200) {
            main.innerHTML = xhr.response
        }
    })
    xhr.send()
}
/*
let xhr = new XMLHttpRequest
xhr.open("GET","archivo1.html")
xhr.addEventListener("readystatechange",()=>{
    if(xhr.readyState == 4 && xhr.status == 200){
        main.innerHTML = xhr.response
    }
})
xhr.send()



*/