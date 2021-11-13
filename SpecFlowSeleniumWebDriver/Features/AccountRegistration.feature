Feature: Account Registration

	Como um usuário 
	Gostaria de cadastrar contas
	Para que eu possa distribuir meu dinheiro de uma forma mais organizada	
	
Scenario Outline: Validação de regras para cadastro de contas
	Given que estou logado na aplicação	
	When cadastro a conta <conta>
	Then recebo a mensagem <mensagem>	
	Examples:
	| conta                    | mensagem                           |
	| Conta de Teste do Thiago | Conta adicionada com sucesso!      |
	|                          | Informe o nome da conta            |
	| Conta mesmo nome         | Já existe uma conta com esse nome! |