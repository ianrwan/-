===go_castle===
今天天氣真好 #speaker: npc_village_1
你不覺得嗎
（我不覺得，我只覺得好熱）#speaker: hero
->END

===help_1===
我剛剛接到一個訂單要在明天製作花蜜給王城 #speaker: npc_village_1
但現在製作花蜜的花朵材料不太夠
你可以幫我採一些花蜜嗎？
    * [可以]
        真的嗎！真是太感謝你了！#mission: get_flower
        王城外面就有可以製作花蜜的花朵材料了
        你可以去那邊看看
        ->DONE
    * [不可以]
        切，現在的年輕人，只是幫忙做點小事也不肯
        果然一代不如一代
        （老太婆，我又沒有義務要幫你）　#speaker: hero
        ->DONE
->END

===mission_1===
王城外面就有可以製作花蜜的花朵材料囉 #speaker: npc_village_1
拿到了再交給我
->END

===mission_1_complete===
謝謝你幫我採花，這個蜂蜜就送你吧 #speaker: npc_village_1
勇者獲得了一個蜂蜜 #namepanel: off
->END

===mission_1_finish===
多虧有你的幫忙 #speaker: npc_village_1
我才來得及將花蜜做好送到王城
不然只有我一個人可能只能放棄這份訂單了 
->END