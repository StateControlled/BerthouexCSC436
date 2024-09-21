import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import TopicCreator from './TopicCreator';
import TopicList from './TopicList';
import NavHeader from './NavHeader';

function ViewPort() {
    return (
      <Container>
        <Row>
          <Col> <NavHeader /> </Col>
        </Row>

        <Row>
          <Col sm={4}> <TopicCreator /> </Col>
          <Col sm={8}> <TopicList /> </Col>
        </Row>
      </Container>
    );
}
  
export default ViewPort;
