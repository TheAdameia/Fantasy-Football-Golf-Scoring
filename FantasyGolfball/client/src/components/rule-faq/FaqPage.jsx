import "./Faq.css"

export const FaqPage = () => {

    return (
        <div>
            <h3>Frequently Asked Questions</h3>
            <h5>Where am I? What is this place?</h5>
            <article className="faq-article">
                This is Fantasy Golfball. It is a fantasy football webapp with the twist that you're trying to get the lowest possible score instead of the highest possible score. This project is currently in alpha, meaning that some features are missing or unavailable and that all players and related data on the site is either fake or user-created.
            </article>
            <h5>Where can I find documentation and additional information about this website?</h5>
            <article>
                https://github.com/TheAdameia/Fantasy-Football-Golf-Scoring
            </article>
            <h5>
                How do I play?
            </h5>
            <article>
                Create an account, join a League, go through a live draft, set your roster, and see what happens!
            </article>
            <h5>When will I be able to play with real players?</h5>
            <article>
                When the beta is released, you will be able to play through past seasons with real football players and real stats. How fast the weeks progress is a matter of user choice, set at the creation of the league.
            </article>
        </div>
    )
}