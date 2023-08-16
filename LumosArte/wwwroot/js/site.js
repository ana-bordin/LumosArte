// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function menuToggle() {
    const toggleMenu = document.querySelector('.menu');
    toggleMenu.classList.toggle('active')
}


function menu() {
    var estilo = document.querySelector('body > div > nav > ul > li:nth-child(1)').style.display
    if (estilo == 'none') {
        exibirMenu()
    }
    else {
        ocutarMenu()
    }
}

function exibirMenu() {
    for (let index = 1; index <= 4; index++) {
        document.getElementById('item' + index).style.display = 'block'
    }
}

function ocutarMenu() {
    for (let index = 1; index <= 4; index++) {
        document.getElementById('item' + index).style.display = 'none'
    }
}

function categoria() {
    var sub = document.querySelector('#subItem1').style.display

    if (sub == 'none') {
        categoriaAbrir()
    }

    else {
        categoriaFechar()
    }
}

function categoriaAbrir() {
    for (let index = 1; index <= 4; index++) {
        document.getElementById('subItem' + index).style.display = 'block'
    }
}

function categoriaFechar() {
    for (let index = 1; index <= 4; index++) {
        document.getElementById('subItem' + index).style.display = 'none'
    }
}

function rolarPagina(par1, par2) {
    window.scroll(par1, par2)
}

function cadastrar() {
    let nome1 = document.getElementById("nome1").value
    let nome2 = document.getElementById("nome2").value
    let data = document.getElementById("data").value
    let email = document.getElementById("email").value
    let tel = document.getElementById("tel").value
    let nomeU = document.getElementById("nomeU").value
    let senha = document.getElementById("senha").value
    let euLi = document.getElementById("euLi").value

    if (nome1 === "" || nome2 === "" || data === "" || email === "" || tel === "" || nomeU === "" || senha === "") {
        window.alert("Preencha os campos!")
    }

    else {
        window.alert(`Cadastrado com sucesso!`)
        document.location = "loginIn.html"
    }
}


function salvar() {
    window.alert(`Alterado com sucesso`)
}

function cadastrarProduto() {
    let produto = document.getElementById("produto").value
    let linkC = document.getElementById("linkC").value
    let cate = document.getElementById("cate").value

    if (produto === "" || linkC === "" || cate === "0") {
        window.alert(`Preencha os campos!`)
    }

    else {
        window.alert(`Cadastrado com sucesso`)
        document.location = "perfil.html"
    }
}

function enviarDuvida() {
    let email3 = document.getElementById("email3").value
    let assunto = document.getElementById("assunto").value
    let msg = document.getElementById("msg").value

    if (email3 === "" || assunto == "" || msg === "") {
        window.alert(`Preencha os campos!`)
    }

    else {
        window.alert(`Dúvida cadastrada com sucesso, aguarde a resposta por e-mail! :)`)
        document.location = "ajuda.html"
    }
}

function entrarSite() {
    let email4 = document.getElementById("email4").value
    let senha2 = document.getElementById("senha2").value

    if (email4 === "" || senha2 === "") {
        window.alert(`Preencha os campos!`)
    }

    else {
        window.alert(`Bem vindo(a), ${email4}`)
        document.location = "home-user.html"
    }

}

function senha() {
    let email5 = document.getElementById("email5").value


    let codE = window.prompt(`Digite o código enviado no seu e-mail`)
    let cod = 1234
    i = cod

    do {
        if (codE == cod) {
            window.prompt(`Digite sua nova Senha`)
            window.alert(`Pronto, você tem uma nova senha!`)
            document.location = "loginIn.html"
        }

        else {
            window.alert(`Código incorreto`)
        }

    } while (i != 1234);

    return true;
}
