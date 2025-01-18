### **1. Objetivo Principal**
O objetivo do jogador é **sobreviver o maior tempo possível** enquanto destrói asteroides para acumular pontos. O jogo é baseado em habilidade, e a dificuldade aumenta conforme o jogador progride.

---

### **2. Movimentação e Controle da Nave**
- **Rotação**: O jogador pode girar a nave para a esquerda ou direita usando as teclas direcionais ou controles correspondentes.
- **Propulsão**: A nave acelera na direção em que está apontando ao pressionar o botão correspondente (geralmente "para cima" ou "W").
- **Inércia**: O movimento da nave segue as leis da física no espaço, ou seja, mesmo após parar de acelerar, ela continua a se mover até ser desacelerada por forças opostas.
- **Tiros**: O jogador pode disparar projéteis em linha reta na direção em que a nave está apontando. Tiros desaparecem após um curto período de tempo ou ao colidir com um asteroide.

---

### **3. Asteroides**
- Os asteroides aparecem aleatoriamente em posições fora da tela e se movem em direções aleatórias.
- **Subdivisão**:
    - Ao ser atingido por um tiro, um asteroide grande se divide em dois asteroides menores.
    - Asteroides médios se dividem em dois pequenos.
    - Asteroides pequenos são destruídos completamente.
- **Tipos e Pontuação**:
    - Asteroides grandes dão menos pontos.
    - Asteroides pequenos dão mais pontos, recompensando o jogador por destruir subdivisões.

| **Tamanho do Asteroide** | **Divisão**    | **Pontos**  |
|--------------------------|----------------|-------------|
| Grande                   | 2 médios       | 20          |
| Médio                    | 2 pequenos     | 50          |
| Pequeno                  | Destruído      | 100         |

---

### **4. Colisões**
- **Nave e Asteroides**:
    - Se a nave colidir com um asteroide, ela é destruída, e o jogador perde uma vida.
- **Tiros e Asteroides**:
    - Um tiro destrói o asteroide ou o divide (dependendo do tamanho).
- **Tela de Limites**:
    - Se a nave, um tiro ou um asteroide ultrapassar a borda da tela, ele reaparece do lado oposto, criando um efeito de "tela infinita".

---

### **5. Sistema de Pontuação**
- O jogador ganha pontos destruindo asteroides.
- A pontuação aumenta com o tamanho reduzido dos asteroides (pequenos valem mais).
- O objetivo é alcançar a maior pontuação possível.

---

### **6. Vidas e Continuação**
- O jogador começa com um número limitado de vidas (geralmente 3).
- Cada colisão da nave com um asteroide resulta na perda de uma vida.
- Quando todas as vidas são perdidas, o jogo termina.
- Não há "fim" no jogo original: o jogador continua até perder todas as vidas.

---

### **7. Dificuldade Progressiva**
- O jogo aumenta de dificuldade conforme o jogador progride:
    - Mais asteroides aparecem simultaneamente.
    - A velocidade dos asteroides aumenta.
- A dificuldade é calculada por "fases" ou "níveis", com cada fase sendo concluída após todos os asteroides na tela serem destruídos.

---

### **8. Elementos Visuais e Feedback**
- A nave e os tiros são visíveis apenas como formas geométricas simples (triângulo para a nave, linhas para tiros).
- Não há gráficos elaborados, mas o jogo compensa isso com uma experiência dinâmica e fluida.
- O feedback ao jogador é dado por sons simples (disparos, explosões) e pelo contador de pontuação visível na tela.

---

### **9. Restrições de Movimento**
- **Tela Infinita**:
    - Nave, tiros e asteroides reaparecem do lado oposto ao cruzar os limites da tela.
- **Sem Obstáculos Fixos**:
    - Não existem barreiras ou elementos fixos no espaço, apenas os asteroides.

---

### **10. Jogabilidade Contínua**
- O jogo não possui um "final".
- O jogador joga até perder todas as vidas, e a meta é alcançar a maior pontuação possível.
- Ao reiniciar, a pontuação e a dificuldade retornam ao estado inicial.

---

### **Resumo das Regras**
1. Controle a nave para evitar colisões e destruir asteroides.
2. Use os limites da tela para estratégias de fuga.
3. Ganhe pontos ao destruir asteroides e sobreviva o máximo possível.
4. Cada nível aumenta a dificuldade com mais asteroides e velocidades maiores.
5. Quando as vidas acabarem, o jogo termina.