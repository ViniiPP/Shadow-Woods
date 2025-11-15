# Shadow Woods

`Shadow Woods` é um jogo 2D de corrida infinita (endless runner) em desenvolvimento, criado com o motor de jogo Unity. O jogador controla um personagem que corre automaticamente por um cenário, devendo desviar de obstáculos terrestres e aéreos para acumular a maior pontuação possível.

## Sobre o Jogo

O objetivo do jogo é simples: sobreviver o máximo de tempo possível. O jogador deve pular para evitar aranhas e se abaixar para evitar pássaros voadores. A velocidade do jogo aumenta progressivamente, tornando o desafio cada vez maior.

O jogo possui um sistema de mapas dinâmico. O jogador começa em um mapa de floresta (`FirstMap`) e, ao atingir 600 pontos, entra em um mapa de transição (`TransitionMap`). Pouco depois, aos 625 pontos, o cenário muda completamente para um mapa de caverna (`SecondMap`), com novos visuais de chão e fundo.

## Funcionalidades Principais

* **Corrida Infinita:** O chão e os elementos do cenário se movem continuamente para a esquerda, criando a ilusão de corrida infinita.
* **Dificuldade Progressiva:** A velocidade do jogo aumenta gradualmente ao longo do tempo, começando em `5f` e indo até `12f`, controlada pela classe `SpeedGlobal`.
* **Geração de Obstáculos:** O script `EnemySpawn` gera proceduralmente inimigos terrestres (aranhas) e aéreos (pássaros) em intervalos de tempo aleatórios.
* **Transição de Mapas:** O jogo transiciona automaticamente de um cenário de floresta para um de caverna com base na pontuação do jogador.
* **Sistema de Pontuação:** O script `PointUI` gerencia a pontuação, que aumenta com o tempo.
* **Menus Completos:** O jogo inclui um Menu Principal (`Menu.unity`) para iniciar ou sair e uma tela de Game Over (`GameOverManager`) que pausa o jogo e oferece opções de "Tentar Novamente" ou "Sair".

## Estrutura do Projeto

### Scripts Principais

* `Manager.cs`: O script principal que gerencia o estado do jogo. Ele detecta colisões entre o jogador (`Dino`) e os inimigos (`Fly`, `Cactus`). Ao detectar uma colisão, ele aciona o estado de "Game Over", parando o spawn de inimigos, zerando a velocidade global e chamando o `GameOverManager`.
* `Player.cs`: Controla a mecânica de pulo do jogador. Ele usa `Physics2D.OverlapCircle` para verificar se o jogador está no chão (`isGrounded`) e permite o pulo com a tecla `Espaço`.
* `EnemySpawn.cs`: Responsável por instanciar os prefabs de inimigos (`cactusPrefabRef`, `flyPrefabRef`) em posições definidas e com um intervalo de tempo aleatório.
* `groundMovement.cs`: Gerencia o movimento parallax do chão e dos fundos. Este script é crucial, pois também controla a lógica de transição entre o `FirstMap`, `TransitionMap` e `SecondMap` com base na pontuação (`PointUI.score`).
* `SpeedGlobal.cs`: Uma classe estática que define e controla a velocidade do jogo (`speed`), a aceleração (`acceleration`), a velocidade máxima (`maxSpeed`) e o estado de morte do jogador (`isDead`).
* `PointUI.cs`: Um script simples que atualiza o texto da UI (`scoreText`) com a pontuação atual. Possui um método estático `resetarPontos`.
* `ManageMap.cs`: Uma classe que implementa um padrão singleton para rastrear o estado atual do mapa (`FirstMap`, `TransitionMap`, `SecondMap`).
* `GameOverManager.cs`: Gerencia a tela de Game Over. Ele pausa o jogo (`Time.timeScale = 0f`) quando ativado. O método `TentarNovamente()` reseta o tempo, a pontuação, a velocidade global, e recarrega a cena principal do jogo ("Scence").
* `MenuPrincipalManager.cs`: Controla os botões do Menu Principal, permitindo ao jogador iniciar o jogo (carregando a cena "Scence") ou fechar a aplicação.

### Cenas (Scenes)

O projeto está configurado com as seguintes cenas no `EditorBuildSettings.asset`:

1.  `Assets/Scenes/Menu.unity` (Habilitada): A cena inicial do menu principal.
2.  `Assets/Scenes/Scence.unity` (Habilitada): A cena principal onde o jogo acontece.
3.  `Assets/Scenes/SampleScene.unity` (Desabilitada): Uma cena de teste ou exemplo.

## Detalhes Técnicos

### Versão da Unity

* **Editor Version:** `6000.1.9f1`

### Pacotes Principais (Dependencies)

O projeto utiliza vários pacotes do Unity para suas funcionalidades 2D:

* **Renderização:** Universal Render Pipeline (URP) (`com.unity.render-pipelines.universal`)
* **Input:** Unity Input System (`com.unity.inputsystem`)
* **UI:** Unity UI (`com.unity.ugui`)
* **Assets 2D:**
    * 2D Animation (`com.unity.2d.animation`)
    * 2D Tilemap (`com.unity.2d.tilemap`)
    * Aseprite Importer (`com.unity.2d.aseprite`)
    * PSD Importer (`com.unity.2d.psdimporter`)
* **Scripting:** Visual Scripting (`com.unity.visualscripting`)

## Como Executar

1.  Clone este repositório.
2.  Abra o projeto na versão `6000.1.9f1` do Unity Hub.
3.  O Unity irá importar e resolver os pacotes necessários (definidos em `Packages/manifest.json`).
4.  Abra a cena `Assets/Scenes/Menu.unity`.
5.  Pressione **Play** no editor.
6.  Clique no botão "jogar" no menu do jogo para iniciar.
