import Accordion from 'react-bootstrap/Accordion';
import TopicThread from './TopicThread';

function TopicList() {
    return (
        <Accordion defaultActiveKey="0">
            <Accordion.Item eventKey="0">
                <Accordion.Header>Accordion Item #1</Accordion.Header>
                <Accordion.Body>
                Test text line 1
                </Accordion.Body>
            </Accordion.Item>

            <Accordion.Item eventKey="1">
                <Accordion.Header>Accordion Item #2</Accordion.Header>
                <Accordion.Body>
                Test Text Line Capital
                </Accordion.Body>
            </Accordion.Item>
        </Accordion>
    );
}

export default TopicList;