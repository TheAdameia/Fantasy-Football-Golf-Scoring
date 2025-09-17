import "./Faq.css"

export const FaqPage = () => {

    return (
        <div className="faq-page">
            <h3>Frequently Asked Questions</h3>
            <div className="faq-container">
                <div className="faq-item">
                    <h5 className="faq-question">What is this?</h5>
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
                    <h5 className="faq-question">Where can I find documentation and additional information about this website?</h5>
                    <article className="faq-answer">
                        <a href="github.com/TheAdameia/Fantasy-Football-Golf-Scoring" target="_blank" rel="noopener noreferrer">https://github.com/TheAdameia/Fantasy-Football-Golf-Scoring</a>
                    </article>
                </div>
            </div>
        </div>
    )
}