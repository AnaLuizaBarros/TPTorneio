# TPTorneio
## 1 Especificação do Problema
Um torneio é uma competição popular nos Sete Reinos de Westeros. Torneios em Westeros variam de acordo
com a região em que o torneio é realizado, os desejos do senhor do castelo ou região, e as regras elaboradas
pelo mestre dos jogos. O evento central de muitos torneios westerosi é a justa, em que dois cavaleiros
blindados devem tentar derrubar uns aos outros de suas montarias com uma lança, continuando em pé com
uma variedade de armas embotadas.
Sor Ducan, o Alto, é um escudeiro que acabou de virar cavaleiro e está ansioso para ter suas vitorias em
torneios. Ele decidiu começar no torneio de Vaufreixo, mas ao chegar lá o torneio já havia começado. Antes
de Sor Ducan chegar havia N cavaleiros na competição, numerados de 1 a N. Cada um deles já havia obtido
uma certa quantidade de pontos no torneio, ou seja, o i-ésimo cavaleiro obteve pi pontos.
Sor Ducan vai envolver-se em uma única justa contra cada concorrente. Cada uma das justas do Sor
Ducan termina em uma vitória ou uma derrota. Uma vitória garante um ponto, e uma derrota concede um
ponto ao seu oponente. Para cada justa i, Sor Ducan deve estimar o esforço necessário para vencer a disputa
com seu oponente. Perder uma justa não requer nenhum esforço.
Depois de todas as justas será determinado o rank da competição, onde será exibido a colocação de todos
os cavaleiros e suas premiações. Os cavaleiros serão classificados em ordem decrescente do número de pontos.
Os concorrentes com o mesmo número de pontos de Sor Ducan serão classificados melhores do que ele se eles
tiverem ganhado a justa contra ele e classificados piores caso contrário. O mecanismo exato de desempate
para outros lutadores não é relevante aqui.
O objetivo de Sor Ducan é ficar entre os K melhores cavaleiros do torneio, para assim ser reconhecido
como um bom cavaleiro e ter um bom prêmio. Determine o esforço mínimo necessário que ele precisa investir
para alcançar seu objetivo, se for possível.

## 2 Entrada
A primeira linha contém um par de números inteiros N e K (1 ≤ K ≤ N + 1). As i-ésimas linhas seguintes
contém N linhas com dois números inteiros, separados por um único espaço - pi e ei (0 ≤ pi
, ei ≤ 100000).

## 3 Saída
Imprimir um único número em uma única linha - a quantidade mínima de esforço que Sor Ducan precisa para
se classificar entre os K melhores do torneio. Se nenhuma quantidade de esforço fará com que Sor Ducan
tenha a classificação desejada o número de saída deve ser -1.
A saída não deve ser escrita em nenhum arquivo. Ela deve ser escrita na saída padrão.
