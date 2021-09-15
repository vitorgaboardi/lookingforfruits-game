# lookingforfruits-game

A ideia do jogo é buscar pelas frutas que estão dentro do mapa. Quando o usuário encontrar, deve-se apertar a tecla "F" ou o botão direito para pegar a fruta e inserir no inventório.

Ao usuário comer uma determinada fruta, ela vai gerar poderes adicionais ao longo da fase. Para saber quais poderes serão, teste cada fruta no primeiro nível!

O usuário pode abrir e fechar o inventário ao usar as teclas "B" e "I". Além disso, para consumir uma fruta, basta clicar com o botão esquerdo do mouse na fruta desejada. Tambem é possível jogar a fruta fora.

A medida que a jogador coleta as frutas, novos níveis vão sendo desbloqueados, onde diferentes inimigos vão tentar te matar antes de você pegar as frutas.

Na terceira fase, os inimigos esconderam uma fruta especial. Use sua imaginação para descobrir aonde ela foi alocada.


# Informações das Frutas:

* Maça: Aumenta 30 pontos de vida.
* Pêssego: Dobra a velocidade de movimento
* Limão: Dobra a altura do pulo
* Morango: faz com que o jogador receba a metade de danos normais.

OBS: As informações abaixo mostram o que o jogador deve fazer para passar de fase. Se você quer testar suas habilidades e se surpreender com o jogo, recomenda-se que não leia-as (a menos que esteja com pressa).
OBS2: Na construção original, fez-se uma nova entrada chamada "Inventory" para abrir e fechar o inventário. Nesse caso, é possível criar no Unity uma entrada com essa nomenclatura e colocar a tecla que quiser. Originalmente, as teclas inseridas foram "I" e "B".

# Informações das fases:

* Fase 1: Apenas pegar 4 frutas
* Fase 2: Pegar 4 frutas e desviar das bolas de canhões e do fogo produzido pela colisão das bolas com o chão.
* Fase 3: Adiciona-se uma nova fruta especial que o inimigo escondeu. Exige uma certa habilidade e criatividade do usuário para encontrar (uma bola de canhão ou fogo deve entrar em contato com um tronco de árvore perto das montanhas. Com a colisão, o tronco queima e internamente aparece a fruta adicional para o usuário pegar. Como os tiros de canhão seguem o usuário, ele deve ficar perto até que acerte o tronco. O usuário só consegue passar de fase se conseguir pegar essa 5 fruta).
* Fase 4: Um tiro de canhão a cada segundo.
* Fase 5: Um tiro de canhão a cada meio segundo.
