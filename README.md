# Poker Hands
---
#### Created by Jeremy Pasquino
##### Based on [this Kata/problem](http://codingdojo.org/kata/PokerHands/).

## How to use
---

The program will ask you for both players' hands. Each card has a value and a suit. The suits being clubs, diamonds, hearts, and spades (C, D, H, S, respectively). The values being 2, 3, 4, 5, 6, 7, 8, 9, 10, jack, queen, king, ace (2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A, respectively).

An example of a hand would be as follows: `2H TS AH 3D 5D`. Once you enter both players' hands, the program will print the winning player, and how they won.

## How it works
---
Each hand is assigned a value after the user enters the cards. The values were designed specifically in mind for ties, or in other words, when the 2 players have the same category of hand. The way I decided to tackle this problem was to use decimals in the hand value as well.

For example, the hand `2H 3H 4H 5H 6H` is a straight flush, which would normally be worth `9` points in my program. However, it also takes into account the highest card, which would be the 6 of hearts in this scenerio. The actual value of this hand would be `9.06`. If the other player had the hand `3D 4D 5D 6D 7D`, they would win, as their hand value would be `9.07`.

While doing it this way seemed appropriate, it also made some aspects harder, like displaying the winning card to the user. If I were to approach this problem again, I may think of a different, better way to handle ties in the same category.

## Fun facts
---
- The highest value a hand could have is 9.14, which would be a royal flush (e.g. `TH JH QH KH AH`).
- The closest game you can have without it being a tie would be a high card win. With the hands `8S 7D 6C 5D 3S` vs `8C 7H 6H 5C 2D` you would have the values `0.087653` vs `0.087652`, or only a difference of `0.000001`!
