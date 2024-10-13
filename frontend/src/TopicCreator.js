import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';

function TopicCreator({addTopic}) {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow  = () => setShow(true);

    const ModalHeader = "Create a New Topic";

    function saveTopic(e) {
        e.preventDefault();
        console.log(e);
        console.log(e.target.formTitle.value);
        console.log(e.target.formContent.value);

        const newTopic = {
            "topic_id": Date.now(),
            "title": e.target.formTitle.value,
            "content": e.target.formContent.value,
            "rating": 0
        };
        addTopic(newTopic);
        handleClose();
    }

    return (
        <div className="Topic">
            <Button variant="primary" onClick={handleShow}>
                {ModalHeader}
            </Button>

            <Modal show={show} onHide={handleClose} animation={false}>
                <Modal.Header closeButton>
                    <Modal.Title>{ModalHeader}</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <Form onSubmit={saveTopic}>
                        <Form.Group className="mb-3" controlId="formTitle">
                            <Form.Label>Topic Subject</Form.Label>
                            <Form.Control type="text" name="formTitle" placeholder="Topic Content" />
                        </Form.Group>
                        
                        <Form.Group className="mb-3" controlId="formContent">
                            <Form.Label>Topic Content</Form.Label>
                            <Form.Control as="textarea" name="formContent" rows={3} />
                        </Form.Group>

                        <Button variant="primary" type="submit">
                            Save Changes
                        </Button>
                    </Form>
                </Modal.Body>

                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
}

export default TopicCreator;