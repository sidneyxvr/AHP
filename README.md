# AHP
Passo a passo para instalar o sistema AHP
1 - instalar o mysql https://dev.mysql.com/downloads/file/?id=476234
2 - criar o banco de banco disponibilizado no repositório no github do projeto
3 - baixa a pasta https://github.com/sidneyxvr/AHP/tree/master/AHP/bin/Debug
4 - executar o aplicativo "AHP.exe" na pasta bin
5 - e correr pro abraço

obs1.:o sistema operacional obrigatoriamente deve ser executado windows 10, ter o banco de dados mysql e as dependências necessárias da linguagem.

obs2.:a senha do banco de dados precisar ser admin123 para o usuário root ou deve ser alterada no programa.

obs2.:possível problema: pode ocorrer um erro de criptografia com o mysql devido a instalação de maneira diferente da configurada no processo de desenvolvimento, para corrigir esse erro é necessário ir na pasta dados, classe BancoDados.cs, assim como para alterar o usuário e senha do banco de dados, e retirar da string de conexão a seguinte parte ;sslmode=none
