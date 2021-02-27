# project-take-api

Este projeto faz parte de um desafio do processo seletivo Take Blip. 

## Dockerfile

O arquivo dockerfile foi construido e adaptado para que seja implantado na plataforma Heroku.

Entretanto, se houver a necessidade/desejo para sua execução em localhost efetue os dois procedimentos abaixo:
* Descomente a linha 23
* Comente a linha 25

## Bot da Take Blip

O arquivo Json do bot se encontra na pasta Repobot

## API do RepoBot

A api do bot foi desenvolvida em Asp Net .Core v5.0 na linguagem C#.
Ela se encontra na pasta ProjectTakeApi e está disponivel no seguinte endpoint:

https://api-project-take.herokuapp.com/

## OpenAPI Specification
Os serviços RESTful foram documentados por meio do Swagger.

http://api-project-take.herokuapp.com/swagger
