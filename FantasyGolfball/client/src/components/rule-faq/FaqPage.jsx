import "./Faq.css"

export const FaqPage = () => {

    return (
        <div className="faq-page">
            <h3>Frequently Asked Questions</h3>
            <div className="faq-container">
                <div className="faq-item">
                    <h5 className="faq-question">What is this?</h5>
                    <article className="faq-answer">
                        This is Fantasy Golfball. It is a fantasy football webapp with the twist that you&apos;re trying to get the lowest possible score instead of the highest possible score. This project is currently in development, meaning that some features may be missing or unavailable.
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
                        <a href="https://github.com/TheAdameia/Fantasy-Football-Golf-Scoring" target="_blank" rel="noopener noreferrer">Fantasy Golfball Github</a>
                    </article>
                </div>
                <div className="faq-item">
                    <h5 className="faq-question">What is &quot;DNP&quot; on a player&apos;s status?</h5>
                    <article className="faq-answer">
                        DNP is short for Does Not Play. Since historical data for injuries is sparse and deeply difficult to integrate, any time a player does not record stats they are recorded as DNP.
                    </article>
                </div>
            </div>
        </div>
    )
}