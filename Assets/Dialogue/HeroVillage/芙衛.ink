VAR hero_name = "瑪寇投"

===go_castle===
今天天氣真好 #speaker: npc_village_1
你不覺得嗎
（我不覺得，我只覺得好熱）#speaker: hero #portrait-panel:on #speaker-portrait: hero_cape_normal 
->END

===help_1===
我剛剛接到一個訂單要在明天製作蜂蜜給王城 #speaker: npc_village_1
王城明天好像要開宴會
（等等，那老頭的女兒都被綁架了，他還有心情開宴會？？）#speaker: hero #portrait-panel:on #speaker-portrait: hero_cape_upset 
但現在製作花蜜的花朵材料不太夠 #speaker: npc_village_1 #portrait-panel:off
你可以幫我採一些花蜜嗎？
    * [可以]
        真的嗎！真是太感謝你了！#mission: get_flower 
        王城外面就有可以製作蜂蜜的花朵材料了
        花的樣子很大一朵，紅色花紋帶著一些白斑
        你可以去那邊看看
        ->DONE
    * [不可以]
        切，現在的年輕人，只是幫忙做點小事也不肯
        果然一代不如一代
        （老太婆，我又沒有義務要幫你）　#speaker: hero #portrait-panel:on #speaker-portrait: hero_cape_mad
        ->DONE
->END

===mission_1===
王城外面就有可以製作花蜜的花朵材料囉 #speaker: npc_village_1
拿到了再交給我
->END

===mission_1_complete===
謝謝你幫我採花，這個蜂蜜就送你吧 #speaker: npc_village_1 
（這臭到爆的蜂蜜真的能喝嗎？）#speaker: hero #mission: get_flower #portrait-panel:on #speaker-portrait:hero_cape_upset
{hero_name}獲得了「芙衛的獨門蜂蜜」 #namepanel: off #portrait-panel:off
->END

===mission_1_finish===
多虧有你的幫忙 #speaker: npc_village_1
我才來得及將蜂蜜做好送到王城
不然只有我一個人可能只能放棄這份訂單了 
->END