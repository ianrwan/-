VAR princess_name = "月子"
VAR kingdom_name = "希爾王國"

===go_castle===
勇者歡迎你的來到 #speaker: king
最近王國附近的魔物有增多的現象
往來王國的商隊被襲擊的頻率也增加了不少
而就在昨天我的愛女{princess_name}只是與商隊前往鄰國洽公
就被不明魔物襲擊
給綁架走了
我十分的著急，要求四傑立馬進行調查
根據四傑所秉告的內容
似乎是魔王又再次重新崛起了
但魔王依照傳說只有勇者有辦法討伐
為了愛女也為了王國的和平
我在此以{kingdom_name}之名，賜予你討伐魔王的使命
->question

===question===
你應該會同意吧 #speaker: king
    * [同意] 
        （這情況看來是不能不答應） #speaker: hero #mission: defeat_boss
        不愧是勇者我就知道你會答應 #speaker: king
        這是傳說的勇者之劍，我就將其借給你直到討伐完魔王
        （蛤，我要幫你討伐魔王你卻只把勇者之劍借我而已）#speaker: hero
        你獲得了勇者之劍 #namepanel: off
        ->DONE
    * [不同意]
        -> question
->END

===mission_proceed_1===
我等你把魔王討伐的好消息
->END