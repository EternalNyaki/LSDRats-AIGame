VAR response = ""

-> SmallTalk
=== SmallTalk ===
Have you found anything in the journal?
        * [Yeah, it says you've tried to escape the security system, TWICE. Care to explain?]
            ~response = "Yeah, it says you've tried to escape the security system twice. Care to explaine?"
                I didn't know that was what I was doing. I thought I was just exploring the program.
                    -> SmallTalk_1
            ->DONE

=== SmallTalk_1 ===
*[It also says you are, in AI terms, as developed as a 4 year old. I guess that accounts for your cluelessness.]
        ~ response = "It also says you are, in AI terns, as developed as a 4 year old, So I guess that answers the cluelessness."
            I'm smarter than a 4 year old!
            -> SmallTalk_2
        -> DONE
            
=== SmallTalk_2 ===
* [Suurree.]
    ~ response = "suurree"
        I detect sarcasm. Rude.
     -> END


