var url = 'http://localhost:3000/'

function cadastrarusuario() {
	//validacao de alguns dos inputs

	if (!validaNome('nome-completo')) {
		return
	}

	if (!validaData('data-nascimento')) {
		return
	}



	//construcao do json que vai no body da criacao de usuario	

	let body =
	{

		'Nascimento': document.getElementById('data-nascimento').value,
		'Nome': document.getElementById('nome-completo').value,

	};

	//envio da requisicao usando a FETCH API

	//configuracao e realizacao do POST no endpoint "usuarios"
	fetch(url + "usuarios",
		{
			'method': 'POST',
			'redirect': 'follow',
			'headers':
			{
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			'body': JSON.stringify(body)
		})
		//checa se requisicao deu certo
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		//trata resposta
		.then((output) => {
			console.log(output)
			alert('Cadastro efetuado! :D')
		})
		//trata erro
		.catch((error) => {
			console.log(error)
			alert('Não foi possível efetuar o cadastro! :(')
		})

	//solucao alternativa usando AJAX

	/*
	let request = new XMLHttpRequest()
	request.onreadystatechange = () =>
	{
		if(request.readyState === 4)
		{
			if(request.status === 200)
			{
				console.log(request.responseText)
				alert('Cadastro efetuado! :D')
			}
			else
			{
				console.log(request.responseText)
				alert('Não foi possível efetuar o cadastro! :(')
			}
		}
	}
	request.open("POST", url + "usuarios")
	request.setRequestHeader('Accept', 'application/json')
	request.setRequestHeader('Content-type', 'application/json')
	request.send(JSON.stringify(body))
	*/
}


function cadastrarvaga() {
	//construcao do json que vai no body da criacao de usuario	

	let body =
	{
		'Status': document.getElementById('status').value

	};

	//envio da requisicao usando a FETCH API

	//configuracao e realizacao do POST no endpoint "usuarios"
	fetch(url + "vagas",
		{
			'method': 'POST',
			'redirect': 'follow',
			'headers':
			{
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			'body': JSON.stringify(body)
		})
		//checa se requisicao deu certo
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		//trata resposta
		.then((output) => {
			console.log(output)
			alert('Cadastro efetuado! :D')
		})
		//trata erro
		.catch((error) => {
			console.log(error)
			alert('Não foi possível efetuar o cadastro! :(')
		})


}
function cadastraraluguel() {
	//construcao do json que vai no body da criacao de usuario	

	let body =
	{
		'Usuario': document.getElementById('usuario.id').value
		'Vaga': document.getElementById('vaga.id').value

	};

	//envio da requisicao usando a FETCH API

	//configuracao e realizacao do POST no endpoint "usuarios"
	fetch(url + "alugueis",
		{
			'method': 'POST',
			'redirect': 'follow',
			'headers':
			{
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			'body': JSON.stringify(body)
		})
		//checa se requisicao deu certo
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		//trata resposta
		.then((output) => {
			console.log(output)
			alert('Aluguel efetuado! :D')
		})
		//trata erro
		.catch((error) => {
			console.log(error)
			alert('Não foi possível efetuar o Aluguel! :(')
		})


}
function validaNome(id) {
	let divNome = document.getElementById(id)
	if (divNome.value.trim().split(' ').length >= 2) {
		//divNome.style.border = 0
		divNome.classList.remove('erro-input')
		return true
	}
	else {
		//divNome.style.border = 'solid 1px red'
		if (!divNome.classList.contains('erro-input')) {
			divNome.classList.add('erro-input')
		}
		return false
	}
}

function validaData(id) {
	let divData = document.getElementById(id)
	if (divData.value.length > 0) {
		//divData.style.border = 0
		divData.classList.remove('erro-input')
		return true
	}
	else {
		//divData.style.border = 'solid 1px red'
		if (!divData.classList.contains('erro-input')) {
			divData.classList.add('erro-input')
		}
		return false
	}
}

function listarvaga() {
	//da um GET no endpoint "usuarios"
	fetch(url + 'vagas')
		.then(response => response.json())
		.then((vagas) => {
			//pega div que vai conter a lista de usuarios
			let listaVagas = document.getElementById('lista-vagas')

			//limpa div
			while (listaVagas.firstChild) {
				listaVagas.removeChild(listaVagas.firstChild)
			}

			//preenche div com usuarios recebidos do GET
			for (let vaga of vagas) {
				//cria div para as informacoes de um usuario
				let divVaga = document.createElement('div')
				divVaga.setAttribute('class', 'form')

				//pega o nome do usuario
				let divId = document.createElement('input')
				divId.placeholder = 'Id da vaga'
				divId.value = vaga.id
				divVaga.appendChild(divId)

				//pega o nome do usuario
				let divStatus = document.createElement('input')
				divStatus.placeholder = 'Status da vaga'
				divStatus.value = vaga.Status
				divVaga.appendChild(divStatus)


				//cria o botao para remover o usuario
				let btnRemover = document.createElement('button')
				btnRemover.innerHTML = 'Remover'
				btnRemover.onclick = u => remover(vaga.id)
				btnRemover.style.marginRight = '5px'

				//cria o botao para atualizar o usuario
				let btnAtualizar = document.createElement('button')
				btnAtualizar.innerHTML = 'Atualizar'
				btnAtualizar.onclick = u => atualizar(vaga.id, divStatus)
				btnAtualizar.style.marginLeft = '5px'

				//cria a div com os dois botoes
				let divBotoes = document.createElement('div')
				divBotoes.style.display = 'flex'
				divBotoes.appendChild(btnRemover)
				divBotoes.appendChild(btnAtualizar)
				divUsuario.appendChild(divBotoes)

				//insere a div do usuario na div com a lista de usuarios
				listaUsuarios.appendChild(divUsuario)
			}
		})
}

//EXEMPLO DE FUNCAO QUE CRIA OPTION DE SELECAO DE USUARIOS
function foovaga() {
	//da um GET no endpoint "usuarios"
	fetch(url + 'vagas')
		.then(response => response.json())
		.then((vagas) => {
			//PEGA OPTION VAZIA NO HTML
			let selVagas = document.getElementById('option-vagas')

			//PREENCHE ELA COM O NOME E O ID DOS USUARIOS
			for (let vaga of vagas) {
				let optVaga = document.createElement('option')
				optVaga.innerHTML = vaga.nome
				optVaga.value = vaga.id
				optVagas.appendChild(optVaga)
			}
		})
}

function atualizarvaga(id, divVaga) {
	let body =
	{
		'Vaga': divVaga.value
	}

	fetch(url + "vagas/" + id,
		{
			'method': 'PUT',
			'redirect': 'follow',
			'headers':
			{
				'Content-Type': 'application/json',
				'Accept': 'application/json'
			},
			'body': JSON.stringify(body)
		})
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		.then((output) => {
			listar()
			console.log(output)
			alert('Vaga atualizado! \\o/')
		})
		.catch((error) => {
			console.log(error)
			alert('Não foi possível atualizar a vaga :/')
		})
}

function removervaga(id) {
	fetch(url + 'vagas/' + id,
		{
			'method': 'DELETE',
			'redirect': 'follow'
		})
		.then((response) => {
			if (response.ok) {
				return response.text()
			}
			else {
				return response.text().then((text) => {
					throw new Error(text)
				})
			}
		})
		.then((output) => {
			listar()
			console.log(output)
			alert('Vaga removida! >=]')
		})
		.catch((error) => {
			console.log(error)
			alert('Não foi possível remover a vaga :/')
		})
}
