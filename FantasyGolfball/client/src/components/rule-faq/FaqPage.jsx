import "./Faq.css"

export const FaqPage = () => {

    return (
        <div className="faq-page">
            <h3>Frequently Asked Questions</h3>
            <div className="faq-container">
                <div className="faq-item">
                    <h5 className="faq-question">Where am I? What is this place?</h5>
                    <article className="faq-answer">
                        This is Fantasy Golfball. It is a fantasy football webapp with the twist that you're trying to get the lowest possible score instead of the highest possible score. This project is currently in alpha, meaning that some features are missing or unavailable and that all players and related data on the site are either fake or user-created.
                    </article>
                </div>
                <div className="faq-item">
                    <h5 className="faq-question">
                        How do I play?
                    </h5>
                    <article className="faq-answer">
                    <a href="https://fantasygolfball.org/register" target="_blank" rel="noopener noreferrer">Create an account</a>, join a League, go through a live draft, set your roster, and see what happens!
                    </article>
                </div>
                <div className="faq-item">
                    <h5 className="faq-question">When will I be able to play using real football players?</h5>
                    <article className="faq-answer">
                        When the beta is released, you will be able to play through past seasons with real football players and real stats. How fast the weeks progress is a matter of user choice, set at the creation of the league.
                    </article>
                </div>
                <div className="faq-item">
                    <h5 className="faq-question">When there are real players, what rules will there be regarding injured players and players that don't actually see snaps?</h5>
                    <article className="faq-answer">
                        There are rules to address these issues and they will be posted when the beta arrives.
                    </article>
                </div>
                <div className="faq-item">
                    <h5 className="faq-question">Where can I find documentation and additional information about this website?</h5>
                    <article className="faq-answer">
                        <a href="github.com/TheAdameia/Fantasy-Football-Golf-Scoring" target="_blank" rel="noopener noreferrer">https://github.com/TheAdameia/Fantasy-Football-Golf-Scoring</a>
                    </article>
                </div>
            </div>
        </div>
    )
}