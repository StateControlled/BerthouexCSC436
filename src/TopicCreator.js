import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';

function TopicCreator() {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const ModalHeader = "Create a New Topic";

    return (
        <div className="Topic">
            <Button variant="primary" onClick={handleShow}>
                {ModalHeader}
            </Button>

            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>{ModalHeader}</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <Form>
                        <Form.Group className="mb-3" controlId="topicForm.ControlInput1">
                            <Form.Label>Topic Subject</Form.Label>
                            <Form.Control type="text" placeholder="Enter a title for your topic" />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="topicForm.ControlTextarea1">
                            <Form.Label>Topic Content</Form.Label>
                            <Form.Control as="textarea" rows={3} />
                        </Form.Group>
                    </Form>
                </Modal.Body>

                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleClose}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
}

export default TopicCreator;