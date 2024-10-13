import ListGroup from "react-bootstrap/ListGroup";
import Button from "react-bootstrap/Button";
import ButtonGroup from "react-bootstrap/ButtonGroup";

function TopicThread({comments, updateCommentRating}) {

    // Function to update the rating of a comment
    // Describes the updateRating() function which calls updateCommentRating with the comment ID and the delta value
    function updateRating(id, delta) {
        updateCommentRating(id, delta);
    };

    const matchedComments = comments.map((chat, index) => {
        return (
            <ListGroup as="ul" key={index}>
                <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start" key={chat.comment_id}>
                    <div className="ms-2 me-auto">
                        {/** Display the comment title: describes the div that displays the title of the comment. */}
                        <div className="fw-bold">{chat.title}</div>
                        {/** Display the content of the comment */}
                        <p>{chat.content}</p>
                    </div>

                    <div className="accordion-footer-container">
                        {/** Display the comment's rating and buttons to update the rating */}
                        <strong className="accordion-footer"> Rating: {chat.rating}
                            <ButtonGroup size="sm">
                                <Button variant="success" onClick={() => updateRating(chat.comment_id, 1)}>+</Button>
                                <Button variant="danger" onClick={() => updateRating(chat.comment_id, -1)}>-</Button>
                            </ButtonGroup>
                        </strong>
                    </div>
                </ListGroup.Item>
            </ListGroup>
        );
    });

    {/** Render the list of comments */}
    return (
        <div>
            {matchedComments}
        </div>
    );

};

export default TopicThread;