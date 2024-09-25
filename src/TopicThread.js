import { ListGroupItem } from "react-bootstrap";
import ListGroup from "react-bootstrap/ListGroup";

function TopicThread({comments}){

    const matchedComments = comments.map((chat, index) => {
        return (
            <ListGroup as="ul">
                <ListGroup.Item as="li" className="d-flex justify-content-between align-items-start">
                    <div className="ms-2 me-auto">
                        <div className="fw-bold">{chat.title}</div>
                        <p>{chat.content}</p>
                    </div>
                </ListGroup.Item>
            </ListGroup>
        );
    });

    return(
        <div>
            {matchedComments}
        </div>
    );

};

export default TopicThread;