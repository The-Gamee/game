# Опис гри
**Гру в Ренджу** проводять на дошці _19 × 19_ двоє гравців. Один грає чорними каменями, інший — білими.
Партія починається на порожній дошці, а гравці по черзі розміщують камені; першим ходить чорний.
На дошці нанесено _19 горизонтальних і 19 вертикальних ліній_, камені ставлять на їхніх перетинах.
Горизонтальні лінії пронумеровані 1, 2, … 19 зверху вниз, а вертикальні — 1, 2, … 19 зліва направо,
як показано на рисунку 1. Мета гри — розташувати п’ять каменів одного кольору підряд по горизонталі, вертикалі або діагоналі.
У такому разі, як на рис. 1, переміг би чорний. Водночас гравець не оголошується переможцем, якщо послідовність містить більше 
ніж п’ять каменів одного кольору. Дано конфігурацію гри; потрібно написати програму, яка визначить, чи виграли білі, 
чи виграли чорні, чи ще ніхто не виграв. Вхідні дані не міститимуть ситуації, коли одночасно виграють і чорні, і білі, 
а також випадків, де білі чи чорні перемагають більш ніж в одному місці. 
## Вхідні дані
У першому рядку міститься одне ціле число x (1 ≤ x ≤ 11) — кількість тестів. Далі подано самі тести. 
Кожен тест складається з 19 рядків по 19 чисел. Чорний камінь позначено числом 1, білий — 2, відсутність каменя — 0.
## Вихідні дані
Для кожного тесту потрібно вивести один або два рядки. У першому рядку надрукуйте 1, 
якщо перемагають чорні, 2, якщо перемагають білі, і 0,
якщо переможця поки немає. Якщо хтось переміг, у другому рядку виведіть 
номер горизонтальної лінії та номер вертикальної лінії найлівішого каменя з-поміж п’яти послідовних. 
(Якщо п’ятірка каменів стоїть вертикально, оберіть найверхніший камінь) .
